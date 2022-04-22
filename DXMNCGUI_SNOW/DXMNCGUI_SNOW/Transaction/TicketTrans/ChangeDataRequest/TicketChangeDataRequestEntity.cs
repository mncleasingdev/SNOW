using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using BCE.Data;
using DXMNCGUI_SNOW.Controllers;
using DXMNCGUI_SNOW.Controllers.Registry;


namespace DXMNCGUI_SNOW.Transaction.TicketTrans.ChangeDataRequest
{
    public class TicketChangeDataRequestEntity
    {
        private TicketChangeDataRequestDB myTicketChangeDataRequestcommand;
        internal DataSet myDataSet;
        private DataRow myRow;
        private DataTable myHeaderTable;
        private TicketAction myAction;
        private TicketType myDocType;
        public string strErrorGenTicket;
        private string myAppNote;
        internal DataRow Row
        {
            get { return myRow; }
        }
        public TicketChangeDataRequestDB Ticketcommand
        {
            get
            {
                return this.myTicketChangeDataRequestcommand;
            }
        }
        public DataTable DataTableHeader
        {
            get
            {
                return this.myHeaderTable;
            }
        }
        public DataSet TicketDataSet
        {
            get
            {
                return this.myDataSet;
            }
        }
        public string ApprovalNote
        {
            get
            {
                return this.myAppNote;
            }
            set
            {
                this.myAppNote = value;
            }
        }
        public TicketChangeDataRequestEntity(TicketChangeDataRequestDB aTicket, DataSet ds, TicketAction action)
        {
            myTicketChangeDataRequestcommand = aTicket;
            myDataSet = ds;
            this.myAction = action;
            this.myHeaderTable = this.myDataSet.Tables["Header"];
            myRow = myHeaderTable.Rows[0];
            this.myHeaderTable.ColumnChanged += new DataColumnChangeEventHandler(this.myHeaderTable_ColumnChanged);
        }
        private void myLinesTable_RowChanged(object sender, DataRowChangeEventArgs e)
        {

        }
        private void myLinesTable_ColumnChanging(object sender, DataColumnChangeEventArgs e)
        {

        }
        private void myHeaderTable_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {

        }
        private void DetailDataRowDeletedEventHandler(object sender, DataRowChangeEventArgs e)
        {
        }
        private void myLinesTable_RowDeleting(object sender, DataRowChangeEventArgs e)
        {

        }
        private void DetailDataColumnChangeEventHandler(object sender, DataColumnChangeEventArgs e)
        {
        }
        public DataTable LoadDocNoFormatTable()
        {
            DataTable mytable = new DataTable();
            mytable = myTicketChangeDataRequestcommand.DBSetting.GetDataTable("select * from DocNoFormat where DOCTYPE='CD'", false);
            return mytable;
        }
        public DataTable LoadCategoryTable()
        {
            DataTable mytable = new DataTable();
            mytable = myTicketChangeDataRequestcommand.DBSetting.GetDataTable("select Category from [dbo].[Category] where DocType='CD'", false);
            return mytable;
        }
        public DataTable LoadCategorySubTable(string category)
        {
            DataTable mytable = new DataTable();
            string strQuery = "select Category, SubCategory from CategorySub where Category=? order by SubCategory";
            mytable = myTicketChangeDataRequestcommand.DBSetting.GetDataTable(strQuery, false, category);
            return mytable;
        }
        public DataTable LoadApproverTable(string sID)
        {
            object obj = null;
            string sFirstUpline = "", sSecondUpline = "", sThirdUpline = "";
            string strQuery = "select HEAD from Users where NIK=?";
            DataTable mytable = new DataTable();

            obj = myTicketChangeDataRequestcommand.DBSetting.ExecuteScalar(strQuery, sID);
            if(obj != null && obj != DBNull.Value)
            {
                sFirstUpline = obj.ToString();
            }
            obj = myTicketChangeDataRequestcommand.DBSetting.ExecuteScalar(strQuery, sFirstUpline);
            if (obj != null && obj != DBNull.Value)
            {
                sSecondUpline = obj.ToString();
            }
            obj = myTicketChangeDataRequestcommand.DBSetting.ExecuteScalar(strQuery, sSecondUpline);
            if (obj != null && obj != DBNull.Value)
            {
                sThirdUpline = obj.ToString();
            }
            
            strQuery =  "select HEAD, HEADNAME from Users where NIK=? \n";
            strQuery += "UNION ALL \n";
            strQuery += "select HEAD, HEADNAME from Users where NIK=? \n";
            strQuery += "UNION ALL \n";
            strQuery += "select HEAD, HEADNAME from Users where NIK=? \n";
            strQuery += "UNION ALL \n";
            strQuery += "select HEAD, HEADNAME from Users where NIK=? \n";
            mytable = myTicketChangeDataRequestcommand.DBSetting.GetDataTable(strQuery, false, sID, sFirstUpline, sSecondUpline, sThirdUpline);
            return mytable;
        }
        public TicketAction Action
        {
            get
            {
                return this.myAction;
            }
        }
        public TicketType DocType
        {
            get
            {
                return this.myDocType;
            }
        }
        public void Save(string userID, string strDocName, SaveAction saveaction, string strUpline)
        {
            if (saveaction == SaveAction.Approve)
            {
                this.myAction = TicketAction.Approve;
            }
            if (saveaction == SaveAction.Grab)
            {
                this.myAction = TicketAction.Grab;
            }
            if (saveaction == SaveAction.Reject)
            {
                this.myAction = TicketAction.Reject;
            }
            if (saveaction == SaveAction.Cancel)
            {
                this.myAction = TicketAction.Cancel;
            }
            if (saveaction == SaveAction.OverWrite)
            {
                this.myAction = TicketAction.OverWrite;
            }
            {

                bool flag = this.myRow.RowState != DataRowState.Unchanged;

                if (flag)
                {
                    this.myRow["LastModifiedUser"] = (object)userID;
                    this.myRow["LastModifiedTime"] = (object)this.myTicketChangeDataRequestcommand.DBSetting.GetServerTime();
                    if (this.myRow["CreatedUserID"].ToString().Length == 0)
                        this.myRow["CreatedUserID"] = this.myRow["LastModifiedUser"];
                    this.myRow.EndEdit();
                    myTicketChangeDataRequestcommand.SaveEntity(this, strDocName, saveaction, strUpline, userID);
                }
                this.myAction = TicketAction.View;

            }

        }
        public void Edit()
        {
            if (this.myAction == TicketAction.View)
            {
                this.myAction = TicketAction.Edit;
            }
        }
        public object DocKey
        {
            get { return myRow["DocKey"]; }
            set { myRow["DocKey"] = value; }
        }
        public object TicketNo
        {
            get { return myRow["TicketNo"]; }
            set { myRow["TicketNo"] = value; }
        }
        public object TicketReqDate
        {
            get { return myRow["TicketReqDate"]; }
            set { myRow["TicketReqDate"] = value; }
        }
        public object UrgentType
        {
            get { return myRow["UrgentType"]; }
            set { myRow["UrgentType"] = value; }
        }
        public object RefNo
        {
            get { return myRow["RefNo"]; }
            set { myRow["RefNo"] = value; }
        }
        public object Category
        {
            get { return myRow["Category"]; }
            set { myRow["Category"] = value; }
        }
        public object SubCategory
        {
            get { return myRow["SubCategory"]; }
            set { myRow["SubCategory"] = value; }
        }
        public object Description
        {
            get { return myRow["Description"]; }
            set { myRow["Description"] = value; }
        }
        public object Remark1
        {
            get { return myRow["Remark1"]; }
            set { myRow["Remark1"] = value; }
        }
        public object Remark2
        {
            get { return myRow["Remark2"]; }
            set { myRow["Remark2"] = value; }
        }
        public object Remark3
        {
            get { return myRow["Remark3"]; }
            set { myRow["Remark3"] = value; }
        }
        public object Remark4
        {
            get { return myRow["Remark4"]; }
            set { myRow["Remark4"] = value; }
        }
        public object OriginalData
        {
            get { return myRow["OriginalData"]; }
            set { myRow["OriginalData"] = value; }
        }
        public object RequestData
        {
            get { return myRow["RequestData"]; }
            set { myRow["RequestData"] = value; }
        }
        public object ReasonToChange
        {
            get { return myRow["ReasonToChange"]; }
            set { myRow["ReasonToChange"] = value; }
        }
        public object Reason
        {
            get { return myRow["Reason"]; }
            set { myRow["Reason"] = value; }
        }
        public object Attachment
        {
            get { return myRow["Attachment"]; }
            set { myRow["Attachment"] = value; }
        }
        public object IsApprove
        {
            get { return myRow["IsApprove"]; }
            set { myRow["IsApprove"] = value; }
        }
        public object LastApproveDateTime
        {
            get { return myRow["LastApproveDateTime"]; }
            set { myRow["LastApproveDateTime"] = value; }
        }
        public object Approver
        {
            get { return myRow["Approver"]; }
            set { myRow["Approver"] = value; }
        }
        public object Cancelled
        {
            get { return myRow["Cancelled"]; }
            set { myRow["Cancelled"] = value; }
        }
        public object Status
        {
            get { return myRow["Status"]; }
            set { myRow["Status"] = value; }
        }
        public object CreatedUserID
        {
            get { return myRow["CreatedUserID"]; }
            set { myRow["CreatedUserID"] = value; }
        }
        public object CreatedTimeStamp
        {
            get { return myRow["CreatedTimeStamp"]; }
            set { myRow["CreatedTimeStamp"] = value; }
        }
        public object LastModifiedUser
        {
            get { return myRow["LastModifiedUser"]; }
            set { myRow["LastModifiedUser"] = value; }
        }
        public object LastModifiedTime
        {
            get { return myRow["LastModifiedTime"]; }
            set { myRow["LastModifiedTime"] = value; }
        }
        public object CloseDate
        {
            get { return myRow["CloseDate"]; }
            set { myRow["CloseDate"] = value; }
        }
        public object CloseByUser
        {
            get { return myRow["CloseByUser"]; }
            set { myRow["CloseByUser"] = value; }
        }
        public object GrabDate
        {
            get { return myRow["GrabDate"]; }
            set { myRow["GrabDate"] = value; }
        }
        public object GrabByUser
        {
            get { return myRow["GrabByUser"]; }
            set { myRow["GrabByUser"] = value; }
        }
        public object RejectNote
        {
            get { return myRow["RejectNote"]; }
            set { myRow["RejectNote"] = value; }
        }
        public DataTable Tickettable
        {
            get { return myDataSet.Tables[0]; }
        }
    }
}