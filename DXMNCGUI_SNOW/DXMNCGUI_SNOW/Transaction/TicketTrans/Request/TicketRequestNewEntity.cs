using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using BCE.Data;
using DXMNCGUI_SNOW.Controllers;
using DXMNCGUI_SNOW.Controllers.Registry;

namespace DXMNCGUI_SNOW.Transaction.TicketTrans.Request
{
    public class TicketRequestNewEntity
    {
        private TicketRequestDB myTicketRequestNewcommand;
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

        public TicketRequestDB Ticketcommand
        {
            get
            {
                return this.myTicketRequestNewcommand;
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
        public TicketRequestNewEntity(TicketRequestDB aTicket, DataSet ds, TicketAction action)
        {
            myTicketRequestNewcommand = aTicket;
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
            mytable = myTicketRequestNewcommand.DBSetting.GetDataTable("select * from DocNoFormat where DOCTYPE='RQ'", false);
            return mytable;
        }
        public DataTable LoadCategoryTable()
        {
            DataTable mytable = new DataTable();
            mytable = myTicketRequestNewcommand.DBSetting.GetDataTable("select Category from [dbo].[Category] where DocType='RQ'", false);
            return mytable;
        }
        public DataTable LoadCategorySubTable(string category)
        {
            DataTable mytable = new DataTable();
            string strQuery = "select Category, SubCategory from CategorySub where Category=? order by SubCategory";
            mytable = myTicketRequestNewcommand.DBSetting.GetDataTable(strQuery, false, category);
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
        public void Save(string userID, string strDocName, SaveAction saveaction, DataTable dtCopyApp)
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
                    this.myRow["LastModifiedTime"] = (object)this.myTicketRequestNewcommand.DBSetting.GetServerTime();
                    if (this.myRow["CreatedUserID"].ToString().Length == 0)
                        this.myRow["CreatedUserID"] = this.myRow["LastModifiedUser"];
                    this.myRow.EndEdit();
                    myTicketRequestNewcommand.SaveEntity(this, strDocName, saveaction, dtCopyApp);
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
        public object Description2
        {
            get { return myRow["Description2"]; }
            set { myRow["Description2"] = value; }
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
        public object Email
        {
            get { return myRow["Email"]; }
            set { myRow["Email"] = value; }
        }
        public object PcLogin
        {
            get { return myRow["PcLogin"]; }
            set { myRow["PcLogin"] = value; }
        }
        public object SMILE
        {
            get { return myRow["SMILE"]; }
            set { myRow["SMILE"] = value; }
        }
        public object FileZilla
        {
            get { return myRow["FileZilla"]; }
            set { myRow["FileZilla"] = value; }
        }
        public object PINtlp
        {
            get { return myRow["PINtlp"]; }
            set { myRow["PINtlp"] = value; }
        }
        public DataTable Tickettable
        {
            get { return myDataSet.Tables[0]; }
        }
    }
}