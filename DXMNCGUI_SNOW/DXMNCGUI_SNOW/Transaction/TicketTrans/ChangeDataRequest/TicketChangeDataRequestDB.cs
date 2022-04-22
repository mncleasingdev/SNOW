using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using BCE.Data;
using DXMNCGUI_SNOW.Controllers;
using DXMNCGUI_SNOW.Controllers.Registry;
using BCE.AutoCount.RegistryID.PrimaryKeyID;
using BCE.AutoCount.RegistryID.Misc;


namespace DXMNCGUI_SNOW.Transaction.TicketTrans.ChangeDataRequest
{
    public class TicketChangeDataRequestDB
    {
        protected internal SqlDBSetting myDBSetting;
        protected SqlDBSession myDBSession;
        protected DataTable myBrowseTable;
        protected DataTable myBrowseTableDetail;
        protected Controllers.Registry.DBRegistry myDBReg;
        protected DataTable myDataTableAllMaster;
        internal TicketChangeDataRequestDB()
        {
            myBrowseTable = new DataTable();
            myBrowseTableDetail = new DataTable();
        }
        public SqlDBSetting DBSetting
        {
            get { return myDBSetting; }
        }
        public SqlDBSession DBSession
        {
            get { return myDBSession; }
        }
        public Controllers.Registry.DBRegistry DBReg
        {
            get
            {
                return this.myDBReg;
            }
        }
        public DataTable DataTableAllMaster
        {
            get
            {
                return this.myDataTableAllMaster;
            }
        }
        public static TicketChangeDataRequestDB Create(SqlDBSetting dbSetting, SqlDBSession dbSession)
        {
            TicketChangeDataRequestDB aTicket = (TicketChangeDataRequestDB)null; ;
            aTicket = new TicketChangeDataRequestSql();
            aTicket.myDBSetting = dbSetting;
            aTicket.myDBSession = dbSession;
            return aTicket;
        }
        public DataTable BrowseTable
        {
            get { return myBrowseTable; }
        }
        public DataTable BrowseTableDetail
        {
            get { return myBrowseTableDetail; }
        }
        public virtual void Sendmail(string strapprovalID, string strapprovalName, TicketNewEntity Ticket, string strsubject, string strbody, SqlDBSetting dbsetting, bool bsender, bool breject, string strrejectnote, string traveltype, Int64 itravelKey)
        {
        }
        public virtual DataTable LoadBrowseTable(bool bViewAll, string userID)
        {
            return null;
        }
        public virtual DataTable LoadBrowseTableDetail(string sTicketNo)
        {
            return null;
        }
        public TicketChangeDataRequestEntity Entity(TicketType type)
        {
            myDBReg = Controllers.Registry.DBRegistry.Create(myDBSetting);
            DataSet dataSet = LoadData(0);
            DataRow row = dataSet.Tables["Header"].NewRow();
            this.InitNewHeaderRow(row, type);
            dataSet.Tables["Header"].Rows.Add(row);
            return new TicketChangeDataRequestEntity(this, dataSet, TicketAction.New);
        }
        public long NewDocKeyUniqueKey()
        {
            return this.myDBReg.IncOne((Controllers.Registry.IRegistryID)new TicketTransDocKey());
        }
        private void InitNewHeaderRow(DataRow row, TicketType type)
        {
            row.BeginEdit();
            DateTime mydate = myDBSetting.GetServerTime();
            row["DocKey"] = 0;
            row["TicketNo"] = "New";
            row["TicketReqDate"] = mydate;
            row["UrgentType"] = "Urgent";
            row["RefNo"] = "";
            row["Category"] = "";
            row["SubCategory"] = "";
            row["Description"] = DBNull.Value;
            row["Remark1"] = DBNull.Value;
            row["Remark2"] = DBNull.Value;
            row["Remark3"] = DBNull.Value;
            row["Remark4"] = DBNull.Value;
            row["OriginalData"] = DBNull.Value;
            row["RequestData"] = DBNull.Value;
            row["ReasonToChange"] = "";
            row["Reason"] = DBNull.Value;
            row["Attachment"] = DBNull.Value;
            row["IsApprove"] = "F";
            row["LastApproveDateTime"] = DBNull.Value;
            row["Approver"] = "";
            row["Cancelled"] = "F";
            row["Status"] = TransactionAction.Open.ToString().ToUpper();
            row["CreatedUserID"] = myDBSession.LoginUserID;
            row["CreatedTimeStamp"] = myDBSetting.GetServerTime();
            row["LastModifiedUser"] = myDBSession.LoginUserID;
            row["CreatedTimeStamp"] = myDBSetting.GetServerTime();
            row.EndEdit();
        }
        public TicketChangeDataRequestEntity GetEntity(long headerid)
        {
            myDBReg = Controllers.Registry.DBRegistry.Create(myDBSetting);

            DataSet ds = LoadData(headerid);
            if (ds.Tables[0].Rows.Count == 0)
                return null;
            return new TicketChangeDataRequestEntity(this, ds, TicketAction.Edit);
        }
        public TicketChangeDataRequestEntity Edit(long headerid, TicketAction action)
        {
            myDBReg = Controllers.Registry.DBRegistry.Create(myDBSetting);
            return this.InternalEdit(this.LoadData(headerid), action);
        }
        public TicketChangeDataRequestEntity Grab(long headerid, TicketAction action)
        {
            myDBReg = Controllers.Registry.DBRegistry.Create(myDBSetting);
            return this.InternalEdit(this.LoadData(headerid), action);
        }
        public TicketChangeDataRequestEntity Approve(long headerid, TicketAction action)
        {
            myDBReg = Controllers.Registry.DBRegistry.Create(myDBSetting);
            return this.InternalEdit(this.LoadData(headerid), action);
        }
        public TicketChangeDataRequestEntity View(long headerid)
        {
            myDBReg = Controllers.Registry.DBRegistry.Create(myDBSetting);
            return this.InternalView(this.LoadData(headerid));
        }
        public void UpdateAllMaster(DataTable sourceTable)
        {
            if (this.myDataTableAllMaster.PrimaryKey.Length != 0)
            {
                DataRow row = this.myDataTableAllMaster.Rows.Find(sourceTable.Rows[0]["DocKey"]) ?? this.myDataTableAllMaster.NewRow();
                foreach (DataColumn index1 in (InternalDataCollectionBase)row.Table.Columns)
                {
                    int index2 = sourceTable.Columns.IndexOf(index1.ColumnName);
                    if (index2 >= 0)
                        row[index1] = sourceTable.Rows[0][index2];
                }
                row.EndEdit();
                if (row.RowState == DataRowState.Detached)
                    this.myDataTableAllMaster.Rows.Add(row);
            }
        }
        public void DeleteAllMaster(long docKey)
        {
            if (this.myDataTableAllMaster.PrimaryKey.Length != 0)
            {
                DataRow dataRow = this.myDataTableAllMaster.Rows.Find((object)docKey);
                if (dataRow != null)
                    dataRow.Delete();
            }
        }
        private TicketChangeDataRequestEntity InternalView(DataSet newDataSet)
        {
            if (newDataSet.Tables["Header"].Rows.Count == 0)
            {
                return (TicketChangeDataRequestEntity)null;
            }
            else
            {
                long docKey = BCE.Data.Convert.ToInt64(newDataSet.Tables["Header"].Rows[0]["DocKey"]);
                return new TicketChangeDataRequestEntity(this, newDataSet, TicketAction.View);
            }
        }
        private TicketChangeDataRequestEntity InternalEdit(DataSet newDataSet, TicketAction action)
        {
            if (newDataSet.Tables["Header"].Rows.Count == 0)
            {
                return (TicketChangeDataRequestEntity)null;
            }
            else
            {
                long docKey = BCE.Data.Convert.ToInt64(newDataSet.Tables["Header"].Rows[0]["DocKey"]);
                return new TicketChangeDataRequestEntity(this, newDataSet, action);
            }
        }
        public void SaveEntity(TicketChangeDataRequestEntity entity, string strDocName, SaveAction saveaction, string strUpline, string strID)
        {
            if (entity.TicketNo.ToString().Length == 0)
                throw new EmptyTicketpcodeException();


            SaveData(entity, entity.myDataSet, strDocName, saveaction, strUpline, strID);
            LoadBrowseTable(false, myDBSession.LoginUserID);
            try
            {
                if (myBrowseTable.Rows.Count > 0)
                {
                    DataRow r = myBrowseTable.Rows.Find(entity.DocKey);
                    if (r == null)
                    {
                        r = myBrowseTable.NewRow();
                        foreach (DataColumn col in entity.Tickettable.Columns)
                        {
                            if (myBrowseTable.Columns.Contains(col.ColumnName))
                                r[col.ColumnName] = entity.Row[col];
                        }
                        myBrowseTable.Rows.Add(r);
                    }
                    else
                    {
                        foreach (DataColumn col in entity.Tickettable.Columns)
                        {
                            if (myBrowseTable.Columns.Contains(col.ColumnName))
                                r[col.ColumnName] = entity.Row[col];
                        }
                    }
                    myBrowseTable.AcceptChanges();
                }
            }
            catch { }
        }
        protected virtual DataSet LoadData(long headerid)
        {
            return null;
        }
        public virtual void Delete(long headerid)
        {
        }
        protected virtual void SaveData(TicketChangeDataRequestEntity Ticket, DataSet ds, string strDocName, SaveAction saveaction, string strUpline, string userID)
        {
        }
        protected virtual void SaveRequestDetailData(TicketChangeDataRequestEntity Ticket, SaveAction saveaction, string aID)
        {
        }
        protected virtual void SaveWorkingList(TicketChangeDataRequestEntity Ticket, SaveAction saveaction, string myID, string myUpline)
        { }
        protected virtual void DeleteWorkingList(TicketChangeDataRequestEntity Ticket, string myID)
        { }
        protected virtual void UpdateWorkingList()
        { }
    }
}