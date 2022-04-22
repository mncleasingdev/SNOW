using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DXMNCGUI_SNOW.Controllers;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using DevExpress.Web;
using DevExpress.Web.Classes;
using System.Web.SessionState;
using System.Web.Security;
using System.ComponentModel;
using DXMNCGUI_SNOW.Tools;
using System.IO;
using DevExpress.Utils;

namespace DXMNCGUI_SNOW.Transaction.TicketTrans.ChangeDataRequest
{
    public partial class FormTicketChangeDataRequestEntry : BasePage
    {
        const string UploadDirectory = "~/Content/UploadControl/";
        protected SqlDBSetting myDBSetting
        {
            get { isValidLogin(false); return (SqlDBSetting)HttpContext.Current.Session["myDBSetting" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myDBSetting" + this.ViewState["_PageID"]] = value; }
        }
        protected SqlDBSession myDBSession
        {
            get { isValidLogin(false); return (SqlDBSession)HttpContext.Current.Session["myDBSession" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myDBSession" + this.ViewState["_PageID"]] = value; }
        }
        protected DataTable myheadertable
        {
            get { isValidLogin(false); return (DataTable)HttpContext.Current.Session["myheadertable" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myheadertable" + this.ViewState["_PageID"]] = value; }
        }
        protected DataTable myCategoryTable
        {
            get { isValidLogin(false); return (DataTable)HttpContext.Current.Session["myCategoryTable" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myCategoryTable" + this.ViewState["_PageID"]] = value; }
        }
        protected DataTable myCategorySubTable
        {
            get { isValidLogin(false); return (DataTable)HttpContext.Current.Session["myCategorySubTable" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myCategorySubTable" + this.ViewState["_PageID"]] = value; }
        }
        protected DataTable myApproverTable
        {
            get { isValidLogin(false); return (DataTable)HttpContext.Current.Session["myApproverTable" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myApproverTable" + this.ViewState["_PageID"]] = value; }
        }
        protected DataTable myDocNoFormatTable
        {
            get { isValidLogin(false); return (DataTable)HttpContext.Current.Session["myDocNoFormatTable" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myDocNoFormatTable" + this.ViewState["_PageID"]] = value; }
        }
        protected DataTable mySectionTable
        {
            get { isValidLogin(false); return (DataTable)HttpContext.Current.Session["mySectionTable" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["mySectionTable" + this.ViewState["_PageID"]] = value; }
        }
        protected DataSet myds
        {
            get { isValidLogin(false); return (DataSet)HttpContext.Current.Session["myds" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myds" + this.ViewState["_PageID"]] = value; }
        }
        protected TicketAction myAction
        {
            get { isValidLogin(false); return (TicketAction)HttpContext.Current.Session["myAction" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myAction" + this.ViewState["_PageID"]] = value; }
        }
        protected TicketType myDocType
        {
            get { isValidLogin(false); return (TicketType)HttpContext.Current.Session["myDocType" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myDocType" + this.ViewState["_PageID"]] = value; }
        }
        protected TicketChangeDataRequestEntity myTicketChangeDataRequestEntity
        {
            get { isValidLogin(false); return (TicketChangeDataRequestEntity)HttpContext.Current.Session["myTicketChangeDataRequestEntity" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myTicketChangeDataRequestEntity" + this.ViewState["_PageID"]] = value; }
        }
        protected IContainer components
        {
            get { isValidLogin(false); return (IContainer)HttpContext.Current.Session["components" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["components" + this.ViewState["_PageID"]] = value; }
        }
        protected int igridindex
        {
            get { isValidLogin(false); return (int)HttpContext.Current.Session["PurchaseOrderigridindex" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["PurchaseOrderigridindex" + this.ViewState["_PageID"]] = value; }
        }
        protected Int32 iLineID
        {
            get { isValidLogin(false); return (Int32)HttpContext.Current.Session["PurchaseOrderiLINE_ID" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["PurchaseOrderiLINE_ID" + this.ViewState["_PageID"]] = value; }
        }
        protected string strDocName
        {
            get { isValidLogin(false); return (string)HttpContext.Current.Session["PurchaseOrdersstrDocName" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["PurchaseOrdersstrDocName" + this.ViewState["_PageID"]] = value; }
        }
        protected bool bErrorLineSave
        {
            get { isValidLogin(false); return (bool)HttpContext.Current.Session["PurchaseOrderbErrorLineSave" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["PurchaseOrderbErrorLineSave" + this.ViewState["_PageID"]] = value; }
        }
        protected TransactionAction strCancelLine
        {
            get { isValidLogin(false); return (TransactionAction)HttpContext.Current.Session["PurchaseOrderstrCancelLine" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["PurchaseOrderstrCancelLine" + this.ViewState["_PageID"]] = value; }
        }
        protected string strKey
        {
            get { isValidLogin(false); return (string)HttpContext.Current.Session["strKey" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["strKey" + this.ViewState["_PageID"]] = value; }
        }
        protected TicketChangeDataRequestDB myTicketChangeDataRequestDB
        {
            get { isValidLogin(false); return (TicketChangeDataRequestDB)HttpContext.Current.Session["myTicketChangeDataRequestDB" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myTicketChangeDataRequestDB" + this.ViewState["_PageID"]] = value; }
        }
        protected string sFieldName
        {
            get { isValidLogin(false); return (string)HttpContext.Current.Session["PurchaseRequestsFieldName" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["PurchaseRequestsFieldName" + this.ViewState["_PageID"]] = value; }
        }
        protected string sFilePathName
        {
            get { isValidLogin(false); return (string)HttpContext.Current.Session["TicketsFilePathName" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["TicketsFilePathName" + this.ViewState["_PageID"]] = value; }
        }
        protected bool bPreviewDocument
        {
            get { isValidLogin(false); return (bool)HttpContext.Current.Session["bPreviewDocument" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["bPreviewDocument" + this.ViewState["_PageID"]] = value; }
        }
        protected string myStatus
        {
            get { isValidLogin(false); return (string)HttpContext.Current.Session["myStatus" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myStatus" + this.ViewState["_PageID"]] = value; }
        }
        protected string myUpline
        {
            get { isValidLogin(false); return (string)HttpContext.Current.Session["myUpline" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myUpline" + this.ViewState["_PageID"]] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            isValidLogin(false);
            if (!Page.IsPostBack)
            {
                this.ViewState["_PageID"] = Guid.NewGuid();
                myDBSetting = dbsetting;
                myDBSession = dbsession;
                if (this.Request.QueryString["SourceKey"] != null && this.Request.QueryString["Type"] != null)
                {
                    this.myTicketChangeDataRequestDB = TicketChangeDataRequestDB.Create(myDBSetting, myDBSession);
                    myTicketChangeDataRequestEntity = this.myTicketChangeDataRequestDB.View(BCE.Data.Convert.ToInt32(this.Request.QueryString["SourceKey"]));
                }
                myheadertable = new DataTable();
                myCategoryTable = new DataTable();
                myCategorySubTable = new DataTable();
                myApproverTable = new DataTable();
                myDocNoFormatTable = new DataTable();
                mySectionTable = new DataTable();
                strDocName = "";
                igridindex = -1;
                bPreviewDocument = false;
                iLineID = -1;
                myds = new DataSet();
                this.myTicketChangeDataRequestDB = TicketChangeDataRequestDB.Create(myDBSetting, myDBSession);
                strKey = Request.QueryString["Key"];
                SetTicket((TicketChangeDataRequestEntity)HttpContext.Current.Session["myTicketChangeDataRequestEntity" + strKey]);
            }
            if (!IsCallback)
            {

            }
        }
        private void SetTicket(TicketChangeDataRequestEntity TicketChangeDataRequestEntity)
        {
            if (this.myTicketChangeDataRequestEntity != TicketChangeDataRequestEntity)
            {
                if (TicketChangeDataRequestEntity != null)
                {
                    this.myTicketChangeDataRequestEntity = TicketChangeDataRequestEntity;
                }
                myAction = this.myTicketChangeDataRequestEntity.Action;
                myDocType = this.myTicketChangeDataRequestEntity.DocType;
                myds = myTicketChangeDataRequestEntity.myDataSet;
                myStatus = this.myTicketChangeDataRequestEntity.Status.ToString();
                sFilePathName = this.myTicketChangeDataRequestEntity.Attachment.ToString();
                myheadertable = myds.Tables[0];
                setuplookupedit();
                BindingMaster();
                Accessable();
                GetUpline(UserID);
            }
        }
        private void setuplookupedit()
        {
            if (myTicketChangeDataRequestEntity != null)
            {
                DataView dv = new DataView(myTicketChangeDataRequestEntity.LoadDocNoFormatTable());
                myDocNoFormatTable = dv.ToTable();
                myCategoryTable = myTicketChangeDataRequestEntity.LoadCategoryTable();
                cbCategory.DataSource = myCategoryTable;
                cbCategory.DataBind();
                FillCategorySub(myTicketChangeDataRequestEntity.Category.ToString());

                cbReasonChange.Items.Add(new ListEditItem("Kesalahan input user", "Kesalahan input user"));
                cbReasonChange.Items.Add(new ListEditItem("Error program", "Error program"));
                cbReasonChange.Items.Add(new ListEditItem("Kasus khusus", "Kasus khusus"));
            }
            if (myTicketChangeDataRequestEntity != null)
            {
                FillApprover(UserID);
            }
        }
        private void Accessable()
        {
            bool bVisible = true;
            bool bReadOnly = true;
            bool bEnable = true;
            bool bCancel = true;
            bool bGrab = true;
            bool bReject = true;
            bool bOnHold = true;
            bool bAttach = true;
            bool bApprove = true;
            string hexColor = "#FFFF99";
            string roColor = "#EBEBEB";
            DateTime mydate = myDBSetting.GetServerTime();
            bApprove = myTicketChangeDataRequestEntity.IsApprove.ToString() == "T" ? true : false;
            System.Drawing.Color Yellowcolor = System.Drawing.ColorTranslator.FromHtml(hexColor);
            System.Drawing.Color Greycolor = System.Drawing.ColorTranslator.FromHtml(roColor);
            System.Drawing.Color Whitecolor = System.Drawing.Color.White;
            System.Drawing.Color MandatoryColor;
            System.Drawing.Color OptionalColor;

            if (myAction == TicketAction.New)
            {
                ASPxFormLayout1.FindItemOrGroupByName("LayoutGroupDetailTicket").Caption = "New Ticket Entry";
                cbCategory.Focus();
                bReadOnly = false;
                bEnable = true;
                bCancel = false;
                bGrab = false;
                bReject = false;
                bOnHold = false;
                bVisible = false;
                bAttach = true;
            }
            else if (myAction == TicketAction.View)
            {
                ASPxFormLayout1.FindItemOrGroupByName("LayoutGroupDetailTicket").Caption = "View Ticket";
                bReadOnly = true;
                bEnable = false;
                bCancel = true;
                bGrab = false;
                bReject = false;
                bOnHold = false;
                bVisible = true;
                bAttach = false;
            }
            else if (myAction == TicketAction.Grab)
            {
                ASPxFormLayout1.FindItemOrGroupByName("LayoutGroupDetailTicket").Caption = "Grab / Close Ticket";
                bReadOnly = true;
                bEnable = false;
                bCancel = false;
                bGrab = true;
                bReject = true;
                bOnHold = false;
                bVisible = true;
                bAttach = false;

                if (myTicketChangeDataRequestEntity.Status.ToString().Contains("OPEN"))
                {
                    mmReason.BackColor = Greycolor;
                    mmReason.Visible = false;
                    mmReason.Enabled = false;

                    mmRemark1.BackColor = Greycolor;
                    mmRemark1.Visible = false;
                    mmRemark1.Enabled = false;
                }
                if (myTicketChangeDataRequestEntity.Status.ToString().Contains("ON PROGRESS"))
                {
                    btnGrab.Text = "Complete";

                    mmReason.BackColor = Whitecolor;
                    mmReason.Visible = true;
                    mmReason.Enabled = true;

                    mmRemark1.BackColor = Whitecolor;
                    mmRemark1.Visible = true;
                    mmRemark1.Enabled = true;

                    btnOnHold.Enabled = true;
                }
                if (myTicketChangeDataRequestEntity.Status.ToString().Contains("CLOSE"))
                {
                    btnGrab.Enabled = false;
                    btnReject.Enabled = false;
                    btnOnHold.Enabled = false;

                    mmReason.BackColor = Greycolor;
                    mmReason.Visible = true;
                    mmReason.Enabled = false;

                    mmRemark1.BackColor = Greycolor;
                    mmRemark1.Visible = true;
                    mmRemark1.Enabled = false;
                }
                if (myTicketChangeDataRequestEntity.Status.ToString().Contains("REJECT"))
                {
                    btnGrab.Enabled = false;
                    btnReject.Enabled = false;
                    btnOnHold.Enabled = false;

                    mmReason.BackColor = Greycolor;
                    mmReason.Visible = true;
                    mmReason.Enabled = false;

                    mmRemark1.BackColor = Greycolor;
                    mmRemark1.Visible = true;
                    mmRemark1.Enabled = false;
                }
                if (myTicketChangeDataRequestEntity.Status.ToString().Contains("ON HOLD"))
                {
                    btnGrab.Text = "Complete";

                    mmReason.BackColor = Whitecolor;
                    mmReason.Visible = true;
                    mmReason.Enabled = true;

                    mmRemark1.BackColor = Whitecolor;
                    mmRemark1.Visible = true;
                    mmRemark1.Enabled = true;

                    btnOnHold.Enabled = true;
                }
                if (myTicketChangeDataRequestEntity.Status.ToString().Contains("NEED APPROVAL"))
                {
                    bReadOnly = true;
                    bEnable = false;
                    bCancel = false;
                    bGrab = false;
                    bReject = accessright.IsAccessibleByUserID(UserID, "TICKET_CAN_GRAB") ? true : false;
                    bOnHold = false;
                    bVisible = false;
                    bAttach = false;
                }
            }
            else if (myAction == TicketAction.Approve)
            {
                ASPxFormLayout1.FindItemOrGroupByName("LayoutGroupDetailTicket").Caption = "Approve Ticket";
                bReadOnly = true;
                bEnable = true;
                bCancel = false;
                bGrab = false;
                bReject = true;
                bOnHold = false;
                bVisible = true;
                bAttach = false;
                if (myTicketChangeDataRequestEntity.Status.ToString().Contains("NEED APPROVAL"))
                {
                    btnSave.Text = "Approve";
                }
            }

            btnSave.ClientEnabled = bEnable;
            btnCancel.ClientEnabled = bCancel;
            btnGrab.ClientEnabled = bGrab;
            btnReject.ClientEnabled = bReject;
            btnOnHold.ClientEnabled = bOnHold;

            if (bReadOnly)
            {
                MandatoryColor = Greycolor;
                OptionalColor = Greycolor;
            }
            else
            {
                MandatoryColor = Whitecolor;
                OptionalColor = Whitecolor;
            }

            cbCategory.ReadOnly = bReadOnly;
            cbCategory.ForeColor = System.Drawing.Color.Black;
            cbCategory.BackColor = MandatoryColor;

            cbCategorySub.ReadOnly = bReadOnly;
            cbCategorySub.ForeColor = System.Drawing.Color.Black;
            cbCategorySub.BackColor = MandatoryColor;

            cbApprover.ReadOnly = bReadOnly;
            cbApprover.Enabled = bEnable;
            cbApprover.ForeColor = System.Drawing.Color.Black;
            cbApprover.BackColor = MandatoryColor;

            cbReasonChange.ReadOnly = bReadOnly;
            cbReasonChange.ForeColor = System.Drawing.Color.Black;
            cbReasonChange.BackColor = MandatoryColor;

            txtContract.ReadOnly = bReadOnly;
            txtContract.ForeColor = System.Drawing.Color.Black;
            txtContract.BackColor = MandatoryColor;

            mmDescription.ReadOnly = bReadOnly;
            mmDescription.ForeColor = System.Drawing.Color.Black;
            mmDescription.BackColor = MandatoryColor;

            mmOriginalData.ReadOnly = bReadOnly;
            mmOriginalData.ForeColor = System.Drawing.Color.Black;
            mmOriginalData.BackColor = MandatoryColor;

            mmRequestData.ReadOnly = bReadOnly;
            mmRequestData.ForeColor = System.Drawing.Color.Black;
            mmRequestData.BackColor = MandatoryColor;

            mmReason.ForeColor = System.Drawing.Color.Black;
            mmReason.BackColor = MandatoryColor;

            mmRemark1.ForeColor = System.Drawing.Color.Black;
            mmRemark1.BackColor = MandatoryColor;

            CtlUpload.ClientEnabled = bAttach;
            CtlUpload.ForeColor = System.Drawing.Color.Black;
            CtlUpload.BackColor = MandatoryColor;

            if (myTicketChangeDataRequestEntity.Attachment.ToString().Length > 0)
                btnDownload.ClientVisible = bVisible;

            if (myAction != TicketAction.New)
            {
                if (accessright.IsAccessibleByUserID(UserID, "TICKET_CAN_GRAB"))
                {
                    if(myTicketChangeDataRequestEntity.Status.ToString().Contains("APPROVE") || myTicketChangeDataRequestEntity.Status.ToString().Contains("ON HOLD") || myTicketChangeDataRequestEntity.Status.ToString().Contains("ON PROGRESS"))
                    {
                        cbReasonChange.ReadOnly = false;
                        cbReasonChange.ForeColor = System.Drawing.Color.Black;
                        cbReasonChange.BackColor = System.Drawing.Color.Transparent;
                    }
                    if (myAction == TicketAction.Approve)
                    {
                        ASPxFormLayout1.FindItemOrGroupByName("liRejectReason").ClientVisible = myAction == TicketAction.Approve ? true : false;
                    }
                    if (bApprove)
                    {
                        btnGrab.ClientEnabled = true;
                        btnReject.ClientEnabled = true;
                        btnOnHold.ClientEnabled = true;
                    }
                    if (myTicketChangeDataRequestEntity.Status.ToString().Contains("REJECT") || myTicketChangeDataRequestEntity.Status.ToString().Contains("CLOSE") || myTicketChangeDataRequestEntity.Status.ToString().Contains("NEED APPROVAL"))
                    {

                        if (accessright.IsAccessibleByUserID(UserID, "TICKET_CAN_GRAB") && myTicketChangeDataRequestEntity.Status.ToString().Contains("NEED APPROVAL"))
                        {
                            mmReason.ClientEnabled = true;
                            mmReason.ReadOnly = false;
                            mmReason.BackColor = Whitecolor;

                            mmRemark1.ClientEnabled = true;
                            mmRemark1.ReadOnly = false;
                            mmRemark1.BackColor = Whitecolor;
                        }
                        else
                        {
                            mmReason.ClientEnabled = true;
                            mmReason.ReadOnly = true;
                            mmReason.BackColor = Greycolor;

                            mmRemark1.ClientEnabled = true;
                            mmRemark1.ReadOnly = true;
                            mmRemark1.BackColor = Greycolor;
                        }
                    }
                    else
                    {
                        mmReason.ClientEnabled = true;
                        mmReason.ReadOnly = false;
                        mmReason.BackColor = Whitecolor;

                        mmRemark1.ClientEnabled = true;
                        mmRemark1.ReadOnly = false;
                        mmRemark1.BackColor = Whitecolor;
                    }
                }
                else
                {
                    btnGrab.ClientEnabled = false;
                    btnReject.ClientEnabled = myAction == TicketAction.Approve ? true : false;
                    btnOnHold.ClientEnabled = false;

                    mmReason.ClientEnabled = false;
                    mmReason.ReadOnly = false;
                    mmReason.BackColor = Greycolor;

                    mmRemark1.ClientEnabled = false;
                    mmRemark1.ReadOnly = false;
                    mmRemark1.BackColor = Greycolor;           
                }
            }

            if (myAction == TicketAction.New || myTicketChangeDataRequestEntity.Status.ToString().Contains("OPEN"))
            {
                ASPxFormLayout1.FindItemOrGroupByName("LayoutItemReason").Caption = "";
                mmReason.Visible = false;
                mmReason.BackColor = Greycolor;

                ASPxFormLayout1.FindItemOrGroupByName("LayoutItemRemark1").Caption = "";
                mmRemark1.Visible = false;
                mmRemark1.BackColor = Greycolor;
            }

            if (myAction == TicketAction.Approve && myTicketChangeDataRequestEntity.Status.ToString().Contains("NEED APPROVAL"))
            {
                ASPxFormLayout1.FindItemOrGroupByName("liRejectReason").ClientVisible = true;
            }
            if (myTicketChangeDataRequestEntity.Status.ToString().Contains("REJECT") && myTicketChangeDataRequestEntity.RejectNote.ToString().Length > 0)
            {
                ASPxFormLayout1.FindItemOrGroupByName("liRejectReason").ClientVisible = true;
                mmRejectReason.ReadOnly = true;
                mmRejectReason.BackColor = Greycolor;
            }
            if (myTicketChangeDataRequestEntity.Status.ToString() != "CLOSE" && accessright.IsAccessibleByUserID(UserID, "TICKET_CAN_GRAB"))
            {
                btnOverWrite.ClientVisible = myAction == TicketAction.New ? false : true;

                cbCategory.ReadOnly = false;
                cbCategorySub.ReadOnly = false;
                cbReasonChange.ReadOnly = false;

                cbCategory.BackColor = Whitecolor;
                cbCategorySub.BackColor = Whitecolor;
                cbReasonChange.BackColor = Whitecolor;
            }
        }
        private void BindingMaster()
        {
            txtTicketNo.Text = myTicketChangeDataRequestEntity.TicketNo.ToString();
            txtStatus.Text = myTicketChangeDataRequestEntity.Status.ToString();
            txtContract.Text = myTicketChangeDataRequestEntity.RefNo.ToString();
            deReqDate.Value = myTicketChangeDataRequestEntity.TicketReqDate;
            cbCategory.Value = myTicketChangeDataRequestEntity.Category;
            cbCategorySub.Value = myTicketChangeDataRequestEntity.SubCategory;
            mmDescription.Text = myTicketChangeDataRequestEntity.Description.ToString();
            mmReason.Text = myTicketChangeDataRequestEntity.Reason.ToString();
            mmRemark1.Text = myTicketChangeDataRequestEntity.Remark1.ToString();
            mmOriginalData.Text = myTicketChangeDataRequestEntity.OriginalData.ToString();
            mmRequestData.Text = myTicketChangeDataRequestEntity.RequestData.ToString();
            mmRejectReason.Text = myTicketChangeDataRequestEntity.RejectNote.ToString();
            chkApprove.CheckState = (myTicketChangeDataRequestEntity.IsApprove.ToString() == "T" ? CheckState.Checked : CheckState.Unchecked);
            cbApprover.Value = myTicketChangeDataRequestEntity.Approver + ";" + Convert.ToString(dbsetting.ExecuteScalar("SELECT FULLNAME FROM USERS WHERE NIK=?", myTicketChangeDataRequestEntity.Approver));
            cbReasonChange.Value = myTicketChangeDataRequestEntity.ReasonToChange;
            if (BCE.Data.Convert.TextToBoolean(myTicketChangeDataRequestEntity.Cancelled))
            {
                btnCancel.Text = "UnCancel";
            }
            else
            {
                btnCancel.Text = "Cancel";
            }
        }
        private void GetUpline(string strNIK)
        {
            myUpline = Convert.ToString(dbsetting.ExecuteScalar("SELECT HEAD FROM Users WHERE NIK=?", strNIK));
        }
        protected void FillCategorySub(string strcategory)
        {
            if (string.IsNullOrEmpty(strcategory)) return;
            myCategorySubTable.Clear();
            myCategorySubTable = myTicketChangeDataRequestEntity.LoadCategorySubTable(strcategory);
            cbCategorySub.DataSource = myCategorySubTable;
            cbCategorySub.DataBind();
        }
        protected void FillApprover(string sID)
        {
            if (string.IsNullOrEmpty(sID)) return;
            myApproverTable.Clear();
            myApproverTable = myTicketChangeDataRequestEntity.LoadApproverTable(sID);
            cbApprover.DataSource = myApproverTable;
            cbApprover.DataBind();
        }
        protected void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose();
        }
        private bool Save(SaveAction saveAction)
        {
            bool bSave = true;
            DataTable dtCopyApp = new DataTable();

            myTicketChangeDataRequestEntity.TicketNo = txtTicketNo.Value;
            myTicketChangeDataRequestEntity.RefNo = txtContract.Value;
            myTicketChangeDataRequestEntity.TicketReqDate = deReqDate.Value;
            myTicketChangeDataRequestEntity.Category = cbCategory.Value;
            myTicketChangeDataRequestEntity.SubCategory = cbCategorySub.Value;
            myTicketChangeDataRequestEntity.ReasonToChange = cbReasonChange.Value;
            myTicketChangeDataRequestEntity.Description = mmDescription.Value;
            myTicketChangeDataRequestEntity.Reason = mmReason.Value;
            myTicketChangeDataRequestEntity.Remark1 = mmRemark1.Value;
            myTicketChangeDataRequestEntity.OriginalData = mmOriginalData.Value;
            myTicketChangeDataRequestEntity.RequestData = mmRequestData.Value;
            myTicketChangeDataRequestEntity.Attachment = sFilePathName;
            myTicketChangeDataRequestEntity.LastModifiedUser = UserID;
            myTicketChangeDataRequestEntity.IsApprove = (chkApprove.CheckState == CheckState.Checked ? "T" : "F");
            myTicketChangeDataRequestEntity.Approver = cbApprover.Value;
            myTicketChangeDataRequestEntity.RejectNote = (saveAction == SaveAction.Reject ? mmRejectReason.Value : null);
            if (myAction == TicketAction.New)
            {
                myTicketChangeDataRequestEntity.CreatedUserID = UserID;
                myTicketChangeDataRequestEntity.CreatedTimeStamp = myDBSetting.GetServerTime();
            }
            myTicketChangeDataRequestEntity.LastModifiedTime = myDBSetting.GetServerTime();

            if (saveAction == SaveAction.Save)
            {
                myTicketChangeDataRequestEntity.Status = "NEED APPROVAL";
            }
            else if (saveAction == SaveAction.Grab)
            {
                myTicketChangeDataRequestEntity.Status = "ON PROGRESS";
                myTicketChangeDataRequestEntity.LastModifiedUser = UserID;
                myTicketChangeDataRequestEntity.LastModifiedTime = myDBSetting.GetServerTime();
                myTicketChangeDataRequestEntity.GrabByUser = UserID;
                myTicketChangeDataRequestEntity.GrabDate = myDBSetting.GetServerTime();
            }
            else if (saveAction == SaveAction.Reject)
            {
                myTicketChangeDataRequestEntity.Status = "REJECT";
                myTicketChangeDataRequestEntity.LastModifiedUser = UserID;
                myTicketChangeDataRequestEntity.LastModifiedTime = myDBSetting.GetServerTime();
            }
            else if (saveAction == SaveAction.OnHold)
            {
                myTicketChangeDataRequestEntity.Status = "ON HOLD";
                myTicketChangeDataRequestEntity.LastModifiedUser = UserID;
                myTicketChangeDataRequestEntity.LastModifiedTime = myDBSetting.GetServerTime();
            }
            else if (saveAction == SaveAction.Close)
            {
                myTicketChangeDataRequestEntity.Status = "CLOSE";
                myTicketChangeDataRequestEntity.LastModifiedUser = UserID;
                myTicketChangeDataRequestEntity.LastModifiedTime = myDBSetting.GetServerTime();
                myTicketChangeDataRequestEntity.CloseByUser = UserID;
                myTicketChangeDataRequestEntity.CloseDate = myDBSetting.GetServerTime();
            }
            else if (saveAction == SaveAction.OverWrite)
            {
                myTicketChangeDataRequestEntity.LastModifiedUser = UserID;
                myTicketChangeDataRequestEntity.LastModifiedTime = myDBSetting.GetServerTime();
            }
            myTicketChangeDataRequestEntity.Save(UserID, "CD", saveAction, myUpline);
            return bSave;
        }
        private bool SaveAtt()
        {
            bool bSaveAtt = true;
            if (CtlUpload.UploadedFiles[0] != null)
            {
                sFilePathName = HttpContext.Current.Session["UserID"].ToString() + Guid.NewGuid() + Path.GetExtension(CtlUpload.UploadedFiles[0].FileName);
                string sfilePath = MapPath("~/Upload/" + sFilePathName);
                CtlUpload.UploadedFiles[0].SaveAs(sfilePath);
            }
            else
            {
                bSaveAtt = false;
            }
            return bSaveAtt;
        }
        private bool DownloadAtt()
        {
            bool bDownloadAtt = true;
            FileInfo file = new FileInfo(MapPath(@"~/Upload/" + sFilePathName));
            if (file.Exists)
            {
                Response.Clear();
                Response.ClearHeaders();
                Response.ClearContent();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "text/plain";
                Response.Flush();
                Response.TransmitFile(file.FullName);
                Response.End();
            }
            return bDownloadAtt;
        }
        protected bool ErrorInField(out string strmessageError, SaveAction saveaction)
        {
            bool errorF = false;
            bool focusF = false;
            strmessageError = "";
            cplMain.JSProperties["cplActiveTabIndex"] = 0;
            if (string.IsNullOrEmpty(cbCategory.Text))
            {
                errorF = true;
                cbCategory.IsValid = false;
                cbCategory.ErrorText = "Value can't be empty.";
                if (!focusF)
                {
                    cbCategory.Focus();
                    focusF = true;
                    cplMain.JSProperties["cplblmessageError"] = "Category, can't be empty.";
                    cplMain.JSProperties["cplActiveTabIndex"] = 1;
                }
            }
            if(string.IsNullOrEmpty(cbApprover.Text) || cbApprover.Text.Length < 5)
            {
                errorF = true;
                cbApprover.IsValid = false;
                cbApprover.ErrorText = "Approver can't be empty.";
                strmessageError = "Approver can't be empty.";

                if (!focusF)
                {
                    cbApprover.Focus();
                    focusF = true;
                }
                return errorF;
            }
            if (saveaction == SaveAction.Close)
            {
                if (string.IsNullOrEmpty(mmReason.Text))
                {
                    errorF = true;
                    mmReason.IsValid = false;
                    mmReason.ErrorText = "Value can't be empty.";
                    strmessageError = "Please fill the remarks before close this ticket.";

                    if (!focusF)
                    {
                        mmReason.Focus();
                        focusF = true;
                    }
                    return errorF;
                }
                if (mmReason.Text.Length <= 30)
                {
                    errorF = true;
                    mmReason.IsValid = false;
                    mmReason.ErrorText = "Please fill the remarks with more than 30 characters.";
                    strmessageError = "Please fill the remarks with more than 30 characters.";

                    if (!focusF)
                    {
                        mmReason.Focus();
                        focusF = true;
                    }
                    return errorF;
                }
            }
            if (saveaction == SaveAction.Reject && myTicketChangeDataRequestEntity.Status.ToString() != "NEED APPROVAL")
            {
                if (string.IsNullOrEmpty(mmReason.Text))
                {
                    errorF = true;
                    mmReason.IsValid = false;
                    mmReason.ErrorText = "Value can't be empty.";
                    strmessageError = "Please fill the remarks before reject this ticket.";

                    if (!focusF)
                    {
                        mmReason.Focus();
                        focusF = true;
                    }
                    return errorF;
                }
                if (mmReason.Text.Length <= 30)
                {
                    errorF = true;
                    mmReason.IsValid = false;
                    mmReason.ErrorText = "Please fill the remarks with more than 30 characters.";
                    strmessageError = "Please fill the remarks with more than 30 characters.";

                    if (!focusF)
                    {
                        mmReason.Focus();
                        focusF = true;
                    }
                    return errorF;
                }
            }
            if (saveaction == SaveAction.Reject && myTicketChangeDataRequestEntity.Status.ToString() == "NEED APPROVAL" && !accessright.IsAccessibleByUserID(UserID, "TICKET_CAN_GRAB"))
            {
                if (string.IsNullOrEmpty(mmRejectReason.Text))
                {
                    errorF = true;
                    mmRejectReason.IsValid = false;
                    mmRejectReason.ErrorText = "Value can't be empty.";
                    strmessageError = "Please fill some notes before reject this ticket.";

                    if (!focusF)
                    {
                        mmRejectReason.Focus();
                        focusF = true;
                    }
                    return errorF;
                }
                if (mmRejectReason.Text.Length <= 30)
                {
                    errorF = true;
                    mmRejectReason.IsValid = false;
                    mmRejectReason.ErrorText = "Please fill the reason with more than 30 characters.";
                    strmessageError = "Please fill the reason with more than 30 characters.";

                    if (!focusF)
                    {
                        mmRejectReason.Focus();
                        focusF = true;
                    }
                    return errorF;
                }
            }
            if (saveaction == SaveAction.OnHold)
            {
                if (string.IsNullOrEmpty(mmReason.Text))
                {
                    errorF = true;
                    mmReason.IsValid = false;
                    mmReason.ErrorText = "Value can't be empty.";
                    strmessageError = "Please fill the remarks cause you hold this ticket.";

                    if (!focusF)
                    {
                        mmReason.Focus();
                        focusF = true;
                    }
                    return errorF;
                }
                if (mmReason.Text.Length <= 30)
                {
                    errorF = true;
                    mmReason.IsValid = false;
                    mmReason.ErrorText = "Please fill the remarks with more than 30 characters.";
                    strmessageError = "Please fill the remarks with more than 30 characters.";

                    if (!focusF)
                    {
                        mmReason.Focus();
                        focusF = true;
                    }
                    return errorF;
                }
            }
            return errorF;
        }
        protected void cplMain_Callback(object source, DevExpress.Web.CallbackEventArgs e)
        {
            isValidLogin(false);
            string urlsave = "";
            string[] callbackParam = e.Parameter.ToString().Split(';');
            urlsave = "~/Transaction/TicketTrans/ChangeDataRequest/FormTicketChangeDataRequestMaint.aspx";
            var nameValues = HttpUtility.ParseQueryString(Request.QueryString.ToString());
            nameValues.Set("DocKey", myTicketChangeDataRequestEntity.DocKey.ToString());
            string updatedQueryString = "?" + nameValues.ToString();
            cplMain.JSProperties["cpCallbackParam"] = callbackParam[0].ToUpper();
            object paramName = callbackParam[0].ToUpper();
            object paramValue = callbackParam[1];
            string hexColor = "#FFFF99";
            string roColor = "#EBEBEB";
            string strmessageError = string.Empty;
            DateTime mydate = myDBSetting.GetServerTime();
            System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml(hexColor);
            System.Drawing.Color rocolor = System.Drawing.ColorTranslator.FromHtml(roColor);

            switch (callbackParam[0].ToUpper())
            {
                case "CATEGORY":
                    DataRow[] subrow = myCategorySubTable.Select("Category='" + paramValue + "'", "", DataViewRowState.CurrentRows);
                    if (subrow.Length > 0)
                    {
                        cplMain.JSProperties["cpCategorySub"] = null;
                    }
                    break;
                case "OVERWRITE_CONFIRM":
                    bErrorLineSave = false;
                    cplMain.JSProperties["cplblmessageError"] = "";
                    cplMain.JSProperties["cplblmessage"] = "are you sure want to over-write this ticket?";
                    cplMain.JSProperties["cplblActionButton"] = "OVERWRITE";
                    if (ErrorInField(out strmessageError, SaveAction.OverWrite))
                    {
                        cplMain.JSProperties["cplblmessageError"] = strmessageError;
                    }
                    break;
                case "SAVECONFIRM":
                    if (btnSave.Text.ToUpper() == "SUBMIT")
                    {
                        bErrorLineSave = false;
                        cplMain.JSProperties["cplblmessageError"] = "";
                        cplMain.JSProperties["cplblmessage"] = "are you sure want to submit this ticket?";
                        cplMain.JSProperties["cplblActionButton"] = "SAVE";
                        if (ErrorInField(out strmessageError, SaveAction.Save))
                        {
                            cplMain.JSProperties["cplblmessageError"] = strmessageError;
                        }
                    }
                    else
                    {
                        bErrorLineSave = false;
                        cplMain.JSProperties["cplblmessageError"] = "";
                        cplMain.JSProperties["cplblmessage"] = "are you sure want to approve this ticket?";
                        cplMain.JSProperties["cplblActionButton"] = "SAVE";
                        if (ErrorInField(out strmessageError, SaveAction.Approve))
                        {
                            cplMain.JSProperties["cplblmessageError"] = strmessageError;
                        }
                    }
                    break;
                case "CLOSE_WINDOW_CONFIRM":
                    //cplMain.JSProperties["cplblmessage"] = "are you sure want to close this window?";
                    //cplMain.JSProperties["cplblActionButton"] = "CLOSE";
                    break;
                case "CANCELCONFIRM":
                    cplMain.JSProperties["cplblmessage"] = "are you sure want to " + btnCancel.Text + " this Document?";
                    cplMain.JSProperties["cplblActionButton"] = "CANCEL";
                    cplMain.JSProperties["cpValidF"] = true;
                    cplMain.JSProperties["cplblmessageError"] = strmessageError;
                    SaveAction saveact;
                    if (btnCancel.Text.Contains("UnCancel"))
                        saveact = SaveAction.UnCancel;
                    else
                        saveact = SaveAction.Cancel;
                    if (ErrorInField(out strmessageError, saveact))
                    {
                        cplMain.JSProperties["cplblmessageError"] = strmessageError;

                    }
                    break;
                case "OVERWRITE":
                    Save(SaveAction.OverWrite);
                    cplMain.JSProperties["cpAlertMessage"] = "Transaction over-write has been save...";
                    cplMain.JSProperties["cplblActionButton"] = "OVERWRITE";
                    DevExpress.Web.ASPxWebControl.RedirectOnCallback(urlsave + updatedQueryString);
                    break;
                case "SAVE":
                    if (btnSave.Text.ToUpper() == "SUBMIT")
                    {
                        Save(SaveAction.Save);
                        cplMain.JSProperties["cpAlertMessage"] = "Transaction has been save...";
                        cplMain.JSProperties["cplblActionButton"] = "SAVE";
                        DevExpress.Web.ASPxWebControl.RedirectOnCallback(urlsave + updatedQueryString);
                    }
                    else
                    {
                        Save(SaveAction.Approve);
                        cplMain.JSProperties["cpAlertMessage"] = "Transaction has been approve...";
                        cplMain.JSProperties["cplblActionButton"] = "SAVE";
                        DevExpress.Web.ASPxWebControl.RedirectOnCallback(urlsave + updatedQueryString);
                    }
                    break;
                case "GRAB":
                    if (btnGrab.Text.ToUpper() == "GRAB")
                    {
                        Save(SaveAction.Grab);
                        cplMain.JSProperties["cpAlertMessage"] = "Transaction has been saved...";
                        cplMain.JSProperties["cplblActionButton"] = "GRAB";
                        DevExpress.Web.ASPxWebControl.RedirectOnCallback(urlsave + updatedQueryString);
                    }
                    else
                    {
                        Save(SaveAction.Close);
                        cplMain.JSProperties["cpAlertMessage"] = "Transaction has been closed...";
                        cplMain.JSProperties["cplblActionButton"] = "GRAB";
                        DevExpress.Web.ASPxWebControl.RedirectOnCallback(urlsave + updatedQueryString);
                    }
                    break;
                case "GRABCONFIRM":
                    if (btnGrab.Text.ToUpper() == "GRAB")
                    {
                        cplMain.JSProperties["cplblmessageError"] = "";
                        cplMain.JSProperties["cplblmessage"] = "Are you sure want to grab this ticket?";
                        cplMain.JSProperties["cplblActionButton"] = "GRAB";
                        if (ErrorInField(out strmessageError, SaveAction.Grab))
                        {
                            cplMain.JSProperties["cplblmessageError"] = strmessageError;
                        }
                    }
                    else
                    {
                        cplMain.JSProperties["cplblmessageError"] = "";
                        cplMain.JSProperties["cplblmessage"] = "Are you sure want to close this ticket?";
                        cplMain.JSProperties["cplblActionButton"] = "GRAB";
                        if (ErrorInField(out strmessageError, SaveAction.Close))
                        {
                            cplMain.JSProperties["cplblmessageError"] = strmessageError;
                        }
                    }
                    break;
                case "REJECTCONFIRM":
                    cplMain.JSProperties["cplblmessageError"] = "";
                    cplMain.JSProperties["cplblmessage"] = "Are you sure want to reject this ticket?";
                    cplMain.JSProperties["cplblActionButton"] = "REJECT";
                    if (ErrorInField(out strmessageError, SaveAction.Reject))
                    {
                        cplMain.JSProperties["cplblmessageError"] = strmessageError;
                    }
                    break;
                case "REJECT":
                    if (Save(SaveAction.Reject))
                    {
                        cplMain.JSProperties["cpAlertMessage"] = "This ticket has been rejected...";
                        cplMain.JSProperties["cplblActionButton"] = "REJECT";
                        DevExpress.Web.ASPxWebControl.RedirectOnCallback(urlsave + updatedQueryString);
                    }
                    break;
                case "HOLDCONFIRM":
                    cplMain.JSProperties["cplblmessageError"] = "";
                    cplMain.JSProperties["cplblmessage"] = "Are you sure want to hold this ticket?";
                    cplMain.JSProperties["cplblActionButton"] = "HOLD";
                    if (ErrorInField(out strmessageError, SaveAction.OnHold))
                    {
                        cplMain.JSProperties["cplblmessageError"] = strmessageError;
                    }
                    break;
                case "HOLD":
                    if (Save(SaveAction.OnHold))
                    {
                        cplMain.JSProperties["cpAlertMessage"] = "This ticket has been on hold...";
                        cplMain.JSProperties["cplblActionButton"] = "HOLD";
                        DevExpress.Web.ASPxWebControl.RedirectOnCallback(urlsave + updatedQueryString);
                    }
                    break;
                case "CLOSE":
                    DevExpress.Web.ASPxWebControl.RedirectOnCallback(urlsave + updatedQueryString);
                    break;
                case "CANCEL":
                    if (!BCE.Data.Convert.TextToBoolean(myTicketChangeDataRequestEntity.Cancelled))
                    {
                        Save(SaveAction.Cancel);
                        if (txtStatus.Text == "Complete")
                        {
                        }
                    }
                    else
                    {
                        Save(SaveAction.UnCancel);
                        if (txtStatus.Text == "Complete")
                        {
                        }
                    }
                    DevExpress.Web.ASPxWebControl.RedirectOnCallback(urlsave + updatedQueryString);
                    break;
                case "AFTERUPLOAD":
                    {
                        cplMain.JSProperties["cplblmessage"] = sFilePathName;
                    }
                    break;
                case "PRINT":
                    cplMain.JSProperties["cpDocKey"] = myTicketChangeDataRequestEntity.DocKey;
                    break;
            }
        }
        protected void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void cbCategory_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {

        }
        protected void cbCategory_DataBinding(object sender, EventArgs e)
        {
            (sender as ASPxComboBox).DataSource = myCategoryTable;
        }
        protected void cbCategorySub_Callback(object sender, CallbackEventArgsBase e)
        {
            FillCategorySub(e.Parameter);
        }
        protected void cbCategorySub_DataBinding(object sender, EventArgs e)
        {
            (sender as ASPxComboBox).DataSource = myCategorySubTable;
        }
        protected void CtlUpload_FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            #region SaveAttachment
            try
            {
                if (e.IsValid)
                {
                    SaveAtt();
                }
            }
            catch (Exception ex)
            {
                e.CallbackData = "Sorry, Error :" + ex.Message;
            }
            finally
            {
                if (e.CallbackData == "")
                {
                    e.CallbackData = "Upload success.. !";
                }
            }
            #endregion
        }
        protected void btnDownload_Click(object sender, EventArgs e)
        {
            DownloadAtt();
        }
        protected void btnCloseWindow_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Transaction/TicketTrans/ChangeDataRequest/FormTicketChangeDataRequestMaint.aspx");
        }
        protected void cbApprover_DataBinding(object sender, EventArgs e)
        {
            (sender as ASPxComboBox).DataSource = myApproverTable;
        }
    }
}