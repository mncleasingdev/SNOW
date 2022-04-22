using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using BCE.Data;
using DXMNCGUI_SNOW.Controllers;
using DXMNCGUI_SNOW.Controllers.Registry;
using DXMNCGUI_SNOW.Transaction.TicketTrans.ChangeDataRequest;

namespace DXMNCGUI_SNOW.Transaction.TicketTrans.ChangeDataRequest
{
    public class TicketChangeDataRequestSql : TicketChangeDataRequestDB
    {
        public override DataTable LoadBrowseTable(bool bViewAll, string userID)
        {
            myBrowseTable.Clear();
            if (!bViewAll)
            {
                myDBSetting.LoadDataTable(myBrowseTable, "SELECT *, ChangeDataList.CreatedUserID + ' - ' + Users.FULLNAME as IDFULLNAME FROM dbo.ChangeDataList INNER JOIN Users on ChangeDataList.CreatedUserID = Users.NIK WHERE ChangeDataList.CreatedUserID=? ORDER BY TicketReqDate Desc", true, userID);
            }
            else
            {
                myDBSetting.LoadDataTable(myBrowseTable, "SELECT *, ChangeDataList.CreatedUserID + ' - ' + Users.FULLNAME as IDFULLNAME FROM dbo.ChangeDataList INNER JOIN Users on ChangeDataList.CreatedUserID = Users.NIK ORDER BY TicketReqDate Desc", true);
            }
            DataColumn[] keyHeader = new DataColumn[1];
            keyHeader[0] = myBrowseTable.Columns["DocKey"];
            myBrowseTable.PrimaryKey = keyHeader;
            return myBrowseTable;
        }
        public override DataTable LoadBrowseTableDetail(string sTicketNo)
        {
            myBrowseTableDetail.Clear();
            myDBSetting.LoadDataTable(myBrowseTableDetail, "SELECT ChangeDataListDetail.TicketNo, ChangeDataListDetail.Action, ChangeDataListDetail.ActionDateTime, ChangeDataListDetail.ActionByID + ' - ' + Users.FULLNAME as IDFULLNAME, ChangeDataList.Reason FROM dbo.ChangeDataListDetail INNER JOIN dbo.ChangeDataList ON ChangeDataListDetail.TicketNo = ChangeDataList.TicketNo INNER JOIN Users ON ChangeDataListDetail.ActionByID = Users.NIK WHERE ChangeDataListDetail.TicketNo=? ORDER BY ChangeDataListDetail.ActionDateTime Desc", true, sTicketNo);
            DataColumn[] KeyDetail = new DataColumn[1];
            KeyDetail[0] = myBrowseTableDetail.Columns["DtlKey"];
            myBrowseTableDetail.PrimaryKey = KeyDetail;
            return myBrowseTableDetail;
        }
        protected override DataSet LoadData(long headerid)
        {
            SqlConnection myconn = new SqlConnection(myDBSetting.ConnectionString);
            DataSet dataSet = new DataSet();
            DataTable myHeaderTable = new DataTable();
            DataTable myImageTable = new DataTable();
            string sSQLHeader = "SELECT * FROM dbo.ChangeDataList WHERE DocKey=@DocKey";
            using (SqlCommand cmdheader = new SqlCommand(sSQLHeader, myconn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmdheader);
                cmdheader.Parameters.Add("@DocKey", SqlDbType.BigInt);
                cmdheader.Parameters["@DocKey"].Value = headerid;
                adapter.Fill(myHeaderTable);
            }
            myHeaderTable.TableName = "Header";
            DataColumn[] keyHeader = new DataColumn[1];
            keyHeader[0] = myHeaderTable.Columns["DocKey"];
            myHeaderTable.PrimaryKey = keyHeader;
            dataSet.Tables.Add(myHeaderTable);
            return dataSet;
        }
        public override void Delete(long headerid)
        {
            SqlDBSetting dbSetting = this.myDBSetting.StartTransaction();
            try
            {
                dbSetting.ExecuteNonQuery("DELETE FROM dbo.ChangeDataList WHERE DocKey=?", (object)headerid);
                dbSetting.Commit();

            }
            catch (SqlException ex)
            {
                dbSetting.Rollback();
                throw new ArgumentException(ex.Message);
            }
            catch (HttpUnhandledException ex)
            {
                dbSetting.Rollback();
                throw new ArgumentException(ex.Message);
            }
            catch (Exception ex)
            {
                dbSetting.Rollback();
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                dbSetting.EndTransaction();
            }
        }
        protected override void SaveData(TicketChangeDataRequestEntity Ticket, DataSet ds, string strDocName, SaveAction saveaction, string strUpline, string userID)
        {
            SqlDBSetting dbSetting = this.myDBSetting.StartTransaction();
            SqlConnection con = new SqlConnection(dbSetting.ConnectionString);
            DateTime Mydate = myDBSetting.GetServerTime();
            DataRow dataRow = ds.Tables["Header"].Rows[0];
            try
            {
                dbSetting.StartTransaction();
                if (saveaction == SaveAction.Cancel)
                {
                    dataRow["Cancelled"] = "T";
                }
                if (saveaction == SaveAction.UnCancel)
                {
                    dataRow["Cancelled"] = "F";
                }

                if (saveaction == SaveAction.Save)
                {
                    dataRow["TicketReqDate"] = Mydate;
                    DataRow[] myrowDocNo = dbSetting.GetDataTable("select * from DocNoFormat", false, "").Select("DocType='CD'", "", DataViewRowState.CurrentRows);
                    if (myrowDocNo != null)
                    {
                        dataRow["TicketNo"] = Document.FormatDocumentNo(myrowDocNo[0]["Format"].ToString(), System.Convert.ToInt32(myrowDocNo[0]["NextNo"]), myDBSetting.GetServerTime());
                        dbSetting.ExecuteNonQuery("Update DocNoFormat set NextNo=NextNo+1 Where DocType=?", strDocName);
                    }
                    dbSetting.SimpleSaveDataTable(ds.Tables["Header"], "SELECT * FROM dbo.ChangeDataList");
                    SaveRequestDetailData(Ticket, saveaction, userID);
                    SaveWorkingList(Ticket, saveaction, userID, strUpline);
                }
                else if (saveaction == SaveAction.Approve)
                {
                    string[] sID = Ticket.Approver.ToString().Split(';');
                    if (sID[0].ToUpper() == userID.ToUpper())
                    {
                        dataRow["Status"] = "APPROVE";
                        dataRow["IsApprove"] = "T";
                    }

                    dbSetting.SimpleSaveDataTable(ds.Tables["Header"], "SELECT * FROM dbo.ChangeDataList");
                    SaveRequestDetailData(Ticket, saveaction, userID);
                    DeleteWorkingList(Ticket, userID);

                    if (sID[0].ToUpper() != userID.ToUpper())
                    {
                        SaveWorkingList(Ticket, saveaction, userID, strUpline);
                    }                   
                }
                else if (saveaction == SaveAction.Grab)
                {
                    dbSetting.SimpleSaveDataTable(ds.Tables["Header"], "SELECT * FROM dbo.ChangeDataList");
                    SaveRequestDetailData(Ticket, saveaction, userID);
                }
                else if (saveaction == SaveAction.OnHold)
                {
                    dbSetting.SimpleSaveDataTable(ds.Tables["Header"], "SELECT * FROM dbo.ChangeDataList");
                    SaveRequestDetailData(Ticket, saveaction, userID);
                }
                else if (saveaction == SaveAction.Reject)
                {
                    dbSetting.SimpleSaveDataTable(ds.Tables["Header"], "SELECT * FROM dbo.ChangeDataList");
                    SaveRequestDetailData(Ticket, saveaction, userID);
                    DeleteWorkingList(Ticket, userID);
                }
                else if (saveaction == SaveAction.Close)
                {
                    dbSetting.SimpleSaveDataTable(ds.Tables["Header"], "SELECT * FROM dbo.ChangeDataList");
                    SaveRequestDetailData(Ticket, saveaction, userID);
                }
                if (saveaction == SaveAction.OverWrite)
                {
                    dbSetting.SimpleSaveDataTable(ds.Tables["Header"], "SELECT * FROM dbo.ChangeDataList");
                    SaveRequestDetailData(Ticket, saveaction, Ticket.LastModifiedUser.ToString());
                }

                Ticket.strErrorGenTicket = "null";

                if (Ticket.strErrorGenTicket == "null")
                {
                    dbSetting.Commit();
                    UpdateWorkingList();
                }
                else
                {
                    dbSetting.Rollback();
                    throw new ArgumentException(Ticket.strErrorGenTicket);
                }
            }
            catch (SqlException ex)
            {
                dbSetting.Rollback();
                throw new ArgumentException(ex.Message);
            }
            catch (HttpUnhandledException ex)
            {
                dbSetting.Rollback();
                throw new ArgumentException(ex.Message);
            }
            catch (Exception ex)
            {
                dbSetting.Rollback();
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                dbSetting.EndTransaction();
            }
        }
        protected override void SaveRequestDetailData(TicketChangeDataRequestEntity Ticket, SaveAction saveaction, string aID)
        {
            DateTime Mydate = myDBSetting.GetServerTime();
            SqlConnection myconn = new SqlConnection(myDBSetting.ConnectionString);
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO [dbo].[ChangeDataListDetail] (TicketNo, Action, ActionDateTime, ActionByID) VALUES (@TicketNo, @Action, @ActionDateTime, @ActionByID)");
            sqlCommand.Connection = myconn;
            try
            {
                myconn.Open();
                SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@TicketNo", SqlDbType.NVarChar, 100);
                sqlParameter1.Value = Ticket.TicketNo;
                sqlParameter1.Direction = ParameterDirection.Input;
                SqlParameter sqlParameter2 = sqlCommand.Parameters.Add("@Action", SqlDbType.NVarChar, 100);
                sqlParameter2.Value = saveaction;
                sqlParameter2.Direction = ParameterDirection.Input;
                SqlParameter sqlParameter3 = sqlCommand.Parameters.Add("@ActionDateTime", SqlDbType.DateTime);
                sqlParameter3.Value = Mydate;
                sqlParameter3.Direction = ParameterDirection.Input;
                SqlParameter sqlParameter4 = sqlCommand.Parameters.Add("@ActionByID", SqlDbType.NVarChar, 100);
                sqlParameter4.Value = aID;
                sqlParameter4.Direction = ParameterDirection.Input;
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new ArgumentException(ex.Message);
            }
            catch (HttpUnhandledException ex)
            {
                throw new ArgumentException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                myconn.Close();
                myconn.Dispose();
            }
        }
        protected override void SaveWorkingList(TicketChangeDataRequestEntity Ticket, SaveAction saveaction, string myID, string myUpline)
        {
            DateTime Mydate = myDBSetting.GetServerTime();
            SqlConnection myconn = new SqlConnection(myDBSetting.ConnectionString);
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO [dbo].[WorkList] (TicketNo, TicketDate, TicketRefNo, DocType, UrgentType, SubmitByID, SubmitByUserName, Description, NeedApproveByID, NeedApproveByUserName, TransDate) VALUES (@TicketNo, @TicketDate, @TicketRefNo, @DocType, @UrgentType, @SubmitByID, @SubmitByUserName, @Description, @NeedApproveByID, @NeedApproveByUserName, @TransDate)");
            sqlCommand.Connection = myconn;
            try
            {
                myconn.Open();
                SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@TicketNo", SqlDbType.NVarChar, 100);
                sqlParameter1.Value = Ticket.TicketNo;
                sqlParameter1.Direction = ParameterDirection.Input;
                SqlParameter sqlParameter2 = sqlCommand.Parameters.Add("@TicketDate", SqlDbType.DateTime);
                sqlParameter2.Value = Ticket.TicketReqDate;
                sqlParameter2.Direction = ParameterDirection.Input;
                SqlParameter sqlParameter3 = sqlCommand.Parameters.Add("@TicketRefNo", SqlDbType.NVarChar, 50);
                sqlParameter3.Value = Ticket.RefNo;
                sqlParameter3.Direction = ParameterDirection.Input;
                SqlParameter sqlParameter4 = sqlCommand.Parameters.Add("@DocType", SqlDbType.NVarChar, 20);
                sqlParameter4.Value = "CD";
                sqlParameter4.Direction = ParameterDirection.Input;
                SqlParameter sqlParameter5 = sqlCommand.Parameters.Add("@UrgentType", SqlDbType.NVarChar, 20);
                sqlParameter5.Value = "";
                sqlParameter5.Direction = ParameterDirection.Input;
                SqlParameter sqlParameter6 = sqlCommand.Parameters.Add("@SubmitByID", SqlDbType.NVarChar, 50);
                sqlParameter6.Value = myID;
                sqlParameter6.Direction = ParameterDirection.Input;
                SqlParameter sqlParameter7 = sqlCommand.Parameters.Add("@SubmitByUserName", SqlDbType.NVarChar, 500);
                sqlParameter7.Value = myID;
                sqlParameter7.Direction = ParameterDirection.Input;
                SqlParameter sqlParameter8 = sqlCommand.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlParameter8.Value = "Change data request with number " + Ticket.TicketNo +  " need your approval...";
                sqlParameter8.Direction = ParameterDirection.Input;
                SqlParameter sqlParameter9 = sqlCommand.Parameters.Add("@NeedApproveByID", SqlDbType.NVarChar, 50);
                sqlParameter9.Value = myUpline;
                sqlParameter9.Direction = ParameterDirection.Input;
                SqlParameter sqlParameter10 = sqlCommand.Parameters.Add("@NeedApproveByUserName", SqlDbType.NVarChar, 500);
                sqlParameter10.Value = myUpline;
                sqlParameter10.Direction = ParameterDirection.Input;
                SqlParameter sqlParameter11 = sqlCommand.Parameters.Add("@TransDate", SqlDbType.DateTime);
                sqlParameter11.Value = Mydate;
                sqlParameter11.Direction = ParameterDirection.Input;
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new ArgumentException(ex.Message);
            }
            catch (HttpUnhandledException ex)
            {
                throw new ArgumentException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                myconn.Close();
                myconn.Dispose();
            }
        }
        protected override void DeleteWorkingList(TicketChangeDataRequestEntity Ticket, string myID)
        {
            SqlConnection myconn = new SqlConnection(myDBSetting.ConnectionString);
           //SqlCommand sqlCommand = new SqlCommand("DELETE WorkList WHERE Source=@Source AND NeedApproveByID=@NeedApproveByID");
            SqlCommand sqlCommand = new SqlCommand("DELETE WorkList WHERE Source=@Source");
            sqlCommand.Connection = myconn;
            try
            {
                myconn.Open();
                SqlParameter sqlParameter1 = sqlCommand.Parameters.Add("@Source", SqlDbType.NVarChar, 100);
                sqlParameter1.Value = Ticket.DocKey;
                sqlParameter1.Direction = ParameterDirection.Input;
                //SqlParameter sqlParameter2 = sqlCommand.Parameters.Add("@NeedApproveByID", SqlDbType.NVarChar, 20);
                //sqlParameter2.Value = myID;
                //sqlParameter2.Direction = ParameterDirection.Input;
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new ArgumentException(ex.Message);
            }
            catch (HttpUnhandledException ex)
            {
                throw new ArgumentException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                myconn.Close();
                myconn.Dispose();
            }
        }
        protected override void UpdateWorkingList()
        {
            try
            {
                DBSetting.ExecuteNonQuery("UPDATE dbo.WorkList SET WorkList.Source = (SELECT DocKey FROM dbo.ChangeDataList WHERE WorkList.TicketNo=ChangeDataList.TicketNo)");
            }
            catch (SqlException ex)
            {
                throw new ArgumentException(ex.Message);
            }
            catch (HttpUnhandledException ex)
            {
                throw new ArgumentException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
            }
        }
    }
}