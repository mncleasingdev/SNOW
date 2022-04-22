using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using BCE.Data;
using DXMNCGUI_SNOW.Controllers;
using DXMNCGUI_SNOW.Controllers.Registry;
using DXMNCGUI_SNOW.Transaction.TicketTrans;

namespace DXMNCGUI_SNOW.Transaction.TicketTrans
{
    public class TicketSql : TicketDB
    {
        public override DataTable LoadBrowseTable(bool bViewAll, string userID)
        {
            myBrowseTable.Clear();
            if (!bViewAll)
            {
                myDBSetting.LoadDataTable(myBrowseTable, "SELECT *, IncidentList.CreatedUserID + ' - ' + Users.FULLNAME as IDFULLNAME FROM dbo.IncidentList INNER JOIN Users on IncidentList.CreatedUserID = Users.NIK WHERE IncidentList.CreatedUserID=? ORDER BY TicketReqDate Desc", true, userID);
            }
            else
            {
                myDBSetting.LoadDataTable(myBrowseTable, "SELECT *, IncidentList.CreatedUserID + ' - ' + Users.FULLNAME as IDFULLNAME FROM dbo.IncidentList INNER JOIN Users on IncidentList.CreatedUserID = Users.NIK ORDER BY TicketReqDate Desc", true);
            }
            DataColumn[] keyHeader = new DataColumn[1];
            keyHeader[0] = myBrowseTable.Columns["DocKey"];
            myBrowseTable.PrimaryKey = keyHeader;
            return myBrowseTable;
        }
        public override DataTable LoadBrowseTableDetail(string sTicketNo)
        {
            myBrowseTableDetail.Clear();
            myDBSetting.LoadDataTable(myBrowseTableDetail, "SELECT IncidentListDetail.TicketNo, IncidentListDetail.Action, IncidentListDetail.ActionDateTime, IncidentListDetail.ActionByID + ' - ' + Users.FULLNAME as IDFULLNAME, IncidentList.Reason FROM dbo.IncidentListDetail INNER JOIN dbo.IncidentList on IncidentListDetail.TicketNo = IncidentList.TicketNo INNER JOIN Users ON IncidentListDetail.ActionByID = Users.NIK WHERE IncidentListDetail.TicketNo=? ORDER BY IncidentListDetail.ActionDateTime Desc", true, sTicketNo);
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
            string sSQLHeader = "SELECT * FROM dbo.IncidentList WHERE DocKey=@DocKey";
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
                dbSetting.ExecuteNonQuery("DELETE FROM dbo.IncidentList WHERE DocKey=?", (object)headerid);
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
        protected override void SaveData(TicketNewEntity Ticket, DataSet ds, string strDocName, SaveAction saveaction, DataTable dtCopyApp)
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
                    DataRow[] myrowDocNo = dbSetting.GetDataTable("select * from DocNoFormat", false, "").Select("DocType='IN'", "", DataViewRowState.CurrentRows);
                    if (myrowDocNo != null)
                    {
                        dataRow["TicketNo"] = Document.FormatDocumentNo(myrowDocNo[0]["Format"].ToString(), System.Convert.ToInt32(myrowDocNo[0]["NextNo"]), myDBSetting.GetServerTime());
                        dbSetting.ExecuteNonQuery("Update DocNoFormat set NextNo=NextNo+1 Where DocType=?", strDocName);
                    }                 
                }
                if (saveaction == SaveAction.Submit)
                {
                    dbSetting.SimpleSaveDataTable(ds.Tables["Header"], "SELECT * FROM dbo.IncidentList");
                    SaveIncidentDetailData(Ticket, saveaction, Ticket.LastModifiedUser.ToString());
                }
                if (saveaction == SaveAction.OverWrite)
                {
                    dbSetting.SimpleSaveDataTable(ds.Tables["Header"], "SELECT * FROM dbo.IncidentList");
                    SaveIncidentDetailData(Ticket, saveaction, Ticket.LastModifiedUser.ToString());
                }
                else
                {
                    dbSetting.SimpleSaveDataTable(ds.Tables["Header"], "SELECT * FROM dbo.IncidentList");
                    SaveIncidentDetailData(Ticket, saveaction, Ticket.LastModifiedUser.ToString());
                }
                
                Ticket.strErrorGenTicket = "null";

                if (Ticket.strErrorGenTicket == "null")
                {
                    dbSetting.Commit();
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
        protected override void SaveIncidentDetailData(TicketNewEntity Ticket, SaveAction saveaction, string aID)
        {
            DateTime Mydate = myDBSetting.GetServerTime();
            SqlConnection myconn = new SqlConnection(myDBSetting.ConnectionString);
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO [dbo].[IncidentListDetail] (TicketNo, Action, ActionDateTime, ActionByID) VALUES (@TicketNo, @Action, @ActionDateTime, @ActionByID)");
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
    }
}