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

namespace DXMNCGUI_SNOW.Transaction.TicketTrans.Request
{
    public class TicketRequestDB
    {
        protected internal SqlDBSetting myDBSetting;
        protected SqlDBSession myDBSession;
        protected DataTable myBrowseTable;
        protected DataTable myBrowseTableDetail;
        protected Controllers.Registry.DBRegistry myDBReg;
        protected DataTable myDataTableAllMaster;
        internal TicketRequestDB()
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
        public static TicketRequestDB Create(SqlDBSetting dbSetting, SqlDBSession dbSession)
        {
            TicketRequestDB aTicket = (TicketRequestDB)null; ;
            aTicket = new TicketRequestSql();
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
        public TicketRequestNewEntity NewEntity(TicketType type)
        {
            myDBReg = Controllers.Registry.DBRegistry.Create(myDBSetting);
            DataSet dataSet = LoadData(0);
            DataRow row = dataSet.Tables["Header"].NewRow();
            this.InitNewHeaderRow(row, type);
            dataSet.Tables["Header"].Rows.Add(row);
            return new TicketRequestNewEntity(this, dataSet, TicketAction.New);
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
            row["Category"] = "";
            row["SubCategory"] = "";
            row["Description"] = DBNull.Value;
            row["Reason"] = DBNull.Value;
            row["Attachment"] = DBNull.Value;
            row["Cancelled"] = "F";
            row["Status"] = TransactionAction.Open.ToString().ToUpper();
            row["CreatedUserID"] = myDBSession.LoginUserID;
            row["CreatedTimeStamp"] = myDBSetting.GetServerTime();
            row["LastModifiedUser"] = myDBSession.LoginUserID;
            row["CreatedTimeStamp"] = myDBSetting.GetServerTime();
            row["Email"] = "F";
            row["PcLogin"] = "F";
            row["SMILE"] = "F";
            row["FileZilla"] = "F";
            row["PINtlp"] = "F";
            row.EndEdit();
        }
        public TicketRequestNewEntity GetEntity(long headerid)
        {
            myDBReg = Controllers.Registry.DBRegistry.Create(myDBSetting);

            DataSet ds = LoadData(headerid);
            if (ds.Tables[0].Rows.Count == 0)
                return null;
            return new TicketRequestNewEntity(this, ds, TicketAction.Edit);
        }
        public TicketRequestNewEntity Edit(long headerid, TicketAction action)
        {
            myDBReg = Controllers.Registry.DBRegistry.Create(myDBSetting);
            return this.InternalEdit(this.LoadData(headerid), action);
        }
        public TicketRequestNewEntity Grab(long headerid, TicketAction action)
        {
            myDBReg = Controllers.Registry.DBRegistry.Create(myDBSetting);
            return this.InternalEdit(this.LoadData(headerid), action);
        }
        public TicketRequestNewEntity View(long headerid)
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
        private TicketRequestNewEntity InternalView(DataSet newDataSet)
        {
            if (newDataSet.Tables["Header"].Rows.Count == 0)
            {
                return (TicketRequestNewEntity)null;
            }
            else
            {
                long docKey = BCE.Data.Convert.ToInt64(newDataSet.Tables["Header"].Rows[0]["DocKey"]);
                return new TicketRequestNewEntity(this, newDataSet, TicketAction.View);
            }
        }
        private TicketRequestNewEntity InternalEdit(DataSet newDataSet, TicketAction action)
        {
            if (newDataSet.Tables["Header"].Rows.Count == 0)
            {
                return (TicketRequestNewEntity)null;
            }
            else
            {
                long docKey = BCE.Data.Convert.ToInt64(newDataSet.Tables["Header"].Rows[0]["DocKey"]);
                return new TicketRequestNewEntity(this, newDataSet, action);
            }
        }
        public void SaveEntity(TicketRequestNewEntity entity, string strDocName, SaveAction saveaction, DataTable dtCopyApp)
        {
            if (entity.TicketNo.ToString().Length == 0)
                throw new EmptyTicketpcodeException();


            SaveData(entity, entity.myDataSet, strDocName, saveaction, dtCopyApp);
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
        protected virtual void SaveData(TicketRequestNewEntity Ticket, DataSet ds, string strDocName, SaveAction saveaction, DataTable dtCopyApp)
        {
        }
        protected virtual void SaveRequestDetailData(TicketRequestNewEntity Ticket, SaveAction saveaction, string aID)
        {
        }
    }
}