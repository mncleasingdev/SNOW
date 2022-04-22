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
using DevExpress.Web;
using DevExpress.Utils;

namespace DXMNCGUI_SNOW.Transaction.TicketTrans
{
    public partial class FormTicketEntry : BasePage
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
        protected DataTable myDelToPersonTable
        {
            get { isValidLogin(false); return (DataTable)HttpContext.Current.Session["myDelToPersonTable" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myDelToPersonTable" + this.ViewState["_PageID"]] = value; }
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

        protected TicketNewEntity myTicketEntity
        {
            get { isValidLogin(false); return (TicketNewEntity)HttpContext.Current.Session["myTicketEntity" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myTicketEntity" + this.ViewState["_PageID"]] = value; }
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

        protected int iDistIndex
        {
            get { isValidLogin(false); return (int)HttpContext.Current.Session["PurchaseOrderiDistIndex" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["PurchaseOrderiDistIndex" + this.ViewState["_PageID"]] = value; }
        }
        protected Int32 iDistID
        {
            get { isValidLogin(false); return (Int32)HttpContext.Current.Session["PurchaseOrderiDistID" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["PurchaseOrderiDistID" + this.ViewState["_PageID"]] = value; }
        }

        protected Int32 iSeqLine
        {
            get { isValidLogin(false); return (Int32)HttpContext.Current.Session["PurchaseOrderiSeqLine" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["PurchaseOrderiSeqLine" + this.ViewState["_PageID"]] = value; }
        }
        protected string sFieldNameLines
        {
            get { isValidLogin(false); return (string)HttpContext.Current.Session["PurchaseOrdersFieldNameLines" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["PurchaseOrdersFieldNameLines" + this.ViewState["_PageID"]] = value; }
        }
        protected string sFieldNameDist
        {
            get { isValidLogin(false); return (string)HttpContext.Current.Session["PurchaseOrdersFieldNameDist" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["PurchaseOrdersFieldNameDist" + this.ViewState["_PageID"]] = value; }
        }
        protected string strDocName
        {
            get { isValidLogin(false); return (string)HttpContext.Current.Session["PurchaseOrdersstrDocName" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["PurchaseOrdersstrDocName" + this.ViewState["_PageID"]] = value; }
        }
        protected bool bCancelLine
        {
            get { isValidLogin(false); return (bool)HttpContext.Current.Session["PurchaseOrderbCancelLine" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["PurchaseOrderbCancelLine" + this.ViewState["_PageID"]] = value; }
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
        protected TicketDB myTicketDB
        {
            get { isValidLogin(false); return (TicketDB)HttpContext.Current.Session["myTicketDB" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myTicketDB" + this.ViewState["_PageID"]] = value; }
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
                    this.myTicketDB = TicketDB.Create(myDBSetting, myDBSession);
                    myTicketEntity = this.myTicketDB.View(BCE.Data.Convert.ToInt32(this.Request.QueryString["SourceKey"]));
                }
                myheadertable = new DataTable();
                myCategoryTable = new DataTable();
                myCategorySubTable = new DataTable();
                myDocNoFormatTable = new DataTable();

                myDelToPersonTable = new DataTable();
                mySectionTable = new DataTable();
                sFieldNameLines = "abcd";
                sFieldNameDist = "";
                strDocName = "";
                iDistIndex = -1;
                iDistID = -1;
                igridindex = -1;
                bPreviewDocument = false;
                iLineID = -1;
                myds = new DataSet();
                iSeqLine = 0;
                this.myTicketDB = TicketDB.Create(myDBSetting, myDBSession);
                strKey = Request.QueryString["Key"];
                SetTicket((TicketNewEntity)HttpContext.Current.Session["myTicketEntity" + strKey]);
                bCancelLine = false;
            }
            if (!IsCallback)
            {

            }
        }
        private void SetTicket(TicketNewEntity newTicketEntity)
        {
            if (this.myTicketEntity != newTicketEntity)
            {
                if (newTicketEntity != null)
                {
                    this.myTicketEntity = newTicketEntity;
                }
                myAction = this.myTicketEntity.Action;
                myDocType = this.myTicketEntity.DocType;
                myds = myTicketEntity.myDataSet;
                myStatus = this.myTicketEntity.Status.ToString();
                sFilePathName = this.myTicketEntity.Attachment.ToString();
                myheadertable = myds.Tables[0];
                setuplookupedit();
                BindingMaster();
                Accessable();
            }
        }
        private void setuplookupedit()
        {
            if (myTicketEntity != null)
            {
                DataView dv = new DataView(myTicketEntity.LoadDocNoFormatTable());
                myDocNoFormatTable = dv.ToTable();
                myCategoryTable = myTicketEntity.LoadCategoryTable();
                cbCategory.DataSource = myCategoryTable;
                cbCategory.DataBind();
                FillCategorySub(myTicketEntity.Category.ToString());
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
            string hexColor = "#FFFF99";
            string roColor = "#EBEBEB";
            DateTime mydate = myDBSetting.GetServerTime();
            System.Drawing.Color Yellowcolor = System.Drawing.ColorTranslator.FromHtml(hexColor);
            System.Drawing.Color Greycolor = System.Drawing.ColorTranslator.FromHtml(roColor);
            System.Drawing.Color Whitecolor = System.Drawing.Color.White;
            System.Drawing.Color MandatoryColor;
            System.Drawing.Color OptionalColor;

            if (myAction == TicketAction.New)
            {
                ASPxFormLayout1.FindItemOrGroupByName("FormCaption").Caption = "New Ticket Entry";
                cbCategory.Focus();
                bReadOnly = false;
                bEnable = true;
                bCancel = false;
                bGrab = false;
                bReject = false;
                bOnHold = false;
                bVisible = false;
            }
            else if (myAction == TicketAction.Grab)
            {
                ASPxFormLayout1.FindItemOrGroupByName("FormCaption").Caption = "Grab / Close Ticket";
                ASPxFormLayout1.FindItemOrGroupByName("lytBtnOverWrite").ClientVisible = true;
                bReadOnly = true;
                bEnable = false;
                bCancel = false;
                bGrab = true;
                bReject = true;
                bOnHold = false;
                bVisible = true;

                if (myTicketEntity.Status.ToString() == "OPEN")
                {
                    mmReason.BackColor = Greycolor;
                    mmReason.Visible = false;
                    mmReason.Enabled = false;
                }
                if (myTicketEntity.Status.ToString() == "ON PROGRESS")
                {
                    btnGrab.Text = "Complete";
                    mmReason.BackColor = Whitecolor;
                    mmReason.Visible = true;
                    mmReason.Enabled = true;
                    btnOnHold.Enabled = true;
                }
                if (myTicketEntity.Status.ToString() == "CLOSE")
                {
                    ASPxFormLayout1.FindItemOrGroupByName("lytBtnOverWrite").ClientVisible = false;

                    btnGrab.Enabled = false;
                    btnReject.Enabled = false;
                    btnOnHold.Enabled = false;

                    mmReason.BackColor = Greycolor;
                    mmReason.Visible = true;
                    mmReason.Enabled = false;
                }
                if(myTicketEntity.Status.ToString() == "REJECT")
                {
                    btnGrab.Enabled = false;
                    btnReject.Enabled = false;
                    btnOnHold.Enabled = false;

                    mmReason.BackColor = Greycolor;
                    mmReason.Visible = true;
                    mmReason.Enabled = false;
                }
                if (myTicketEntity.Status.ToString() == "ON HOLD")
                {
                    btnGrab.Text = "Complete";
                    mmReason.BackColor = Whitecolor;
                    mmReason.Visible = true;
                    mmReason.Enabled = true;
                    btnOnHold.Enabled = true;
                }
            }
            else if (myAction == TicketAction.View)
            {
                ASPxFormLayout1.FindItemOrGroupByName("FormCaption").Caption = "View Ticket";
                bReadOnly = true;
                bEnable = false;
                bCancel = true;
                bGrab = false;
                bReject = false;
                bOnHold = false;
                bVisible = true;
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

            mmDescription.ReadOnly = bReadOnly;
            mmDescription.ForeColor = System.Drawing.Color.Black;
            mmDescription.BackColor = MandatoryColor;

            mmReason.ForeColor = System.Drawing.Color.Black;
            mmReason.BackColor = MandatoryColor;

            CtlUpload.ClientEnabled = bEnable;
            CtlUpload.ForeColor = System.Drawing.Color.Black;
            CtlUpload.BackColor = MandatoryColor;

            if (myTicketEntity.Attachment.ToString().Length > 0)
                btnDownload.ClientVisible = bVisible;

            if (myAction != TicketAction.New)
            {
                if (accessright.IsAccessibleByUserID(UserID, "TICKET_CAN_GRAB"))
                {
                    btnGrab.ClientEnabled = true;
                    btnReject.ClientEnabled = true;
                    btnOnHold.ClientEnabled = true;

                    if (myTicketEntity.Status.ToString() == "REJECT" || myTicketEntity.Status.ToString() == "CLOSE")
                    {
                        mmReason.ClientEnabled = true;
                        mmReason.ReadOnly = true;
                        mmReason.BackColor = Greycolor;
                    }
                    else
                    {
                        mmReason.ClientEnabled = true;
                        mmReason.ReadOnly = false;
                        mmReason.BackColor = Whitecolor;
                    }
                }
                else
                {
                    btnGrab.ClientEnabled = false;
                    btnReject.ClientEnabled = false;
                    btnOnHold.ClientEnabled = false;

                    mmReason.ClientEnabled = false;
                    mmReason.ReadOnly = false;
                    mmReason.BackColor = Whitecolor;
                }
            }

            if (myAction == TicketAction.New || myTicketEntity.Status.ToString() == "OPEN")
            {
                ASPxFormLayout1.FindItemOrGroupByName("LayoutItemReason").Caption = "";
                mmReason.Visible = false;
                mmReason.BackColor = Greycolor;

                if (accessright.IsAccessibleByUserID(UserID, "TICKET_CAN_GRAB") && myAction != TicketAction.New)
                {

                }
            }

            if (myTicketEntity.Status.ToString() != "CLOSE" && accessright.IsAccessibleByUserID(UserID, "TICKET_CAN_GRAB"))
            {
                cbCategory.ReadOnly = false;
                cbCategorySub.ReadOnly = false;

                cbCategory.BackColor = Whitecolor;
                cbCategorySub.BackColor = Whitecolor;
            }
        }
        private void BindingMaster()
        {
            txtTicketNo.Text = myTicketEntity.TicketNo.ToString();
            txtStatus.Text = myTicketEntity.Status.ToString();
            deReqDate.Value = myTicketEntity.TicketReqDate;
            cbCategory.Value = myTicketEntity.Category;
            cbCategorySub.Value = myTicketEntity.SubCategory;
            mmDescription.Text = myTicketEntity.Description.ToString();
            mmReason.Text = myTicketEntity.Reason.ToString();
        }
        protected void FillCategorySub(string strcategory)
        {
            if (string.IsNullOrEmpty(strcategory)) return;
            myCategorySubTable.Clear();
            myCategorySubTable = myTicketEntity.LoadCategorySubTable(strcategory);
            cbCategorySub.DataSource = myCategorySubTable;
            cbCategorySub.DataBind();
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

            myTicketEntity.TicketNo = txtTicketNo.Value;
            myTicketEntity.TicketReqDate = deReqDate.Value;
            myTicketEntity.Category = cbCategory.Value;
            myTicketEntity.SubCategory = cbCategorySub.Value;
            myTicketEntity.Description = mmDescription.Value;
            myTicketEntity.Reason = mmReason.Value;
            myTicketEntity.Attachment = sFilePathName;
            myTicketEntity.LastModifiedUser = UserID;
            if (myAction == TicketAction.New)
            {
                myTicketEntity.CreatedUserID = UserID;
                myTicketEntity.CreatedTimeStamp = myDBSetting.GetServerTime();
            }
            myTicketEntity.LastModifiedTime = myDBSetting.GetServerTime();

            if (saveAction == SaveAction.Save)
            {
                myTicketEntity.Status = "OPEN";
            }
            else if (saveAction == SaveAction.Grab)
            {
                myTicketEntity.Status = "ON PROGRESS";
                myTicketEntity.LastModifiedUser = UserID;
                myTicketEntity.LastModifiedTime = myDBSetting.GetServerTime();
                myTicketEntity.GrabByUser = UserID;
                myTicketEntity.GrabDate = myDBSetting.GetServerTime();
            }
            else if (saveAction == SaveAction.Reject)
            {
                myTicketEntity.Status = "REJECT";
                myTicketEntity.LastModifiedUser = UserID;
                myTicketEntity.LastModifiedTime = myDBSetting.GetServerTime();
            }
            else if (saveAction == SaveAction.OnHold)
            {
                myTicketEntity.Status = "ON HOLD";
                myTicketEntity.LastModifiedUser = UserID;
                myTicketEntity.LastModifiedTime = myDBSetting.GetServerTime();
            }
            else if (saveAction == SaveAction.Close)
            {
                myTicketEntity.Status = "CLOSE";
                myTicketEntity.LastModifiedUser = UserID;
                myTicketEntity.LastModifiedTime = myDBSetting.GetServerTime();
                myTicketEntity.CloseByUser = UserID;
                myTicketEntity.CloseDate = myDBSetting.GetServerTime();
            }
            else if (saveAction == SaveAction.OverWrite)
            {
                myTicketEntity.LastModifiedUser = UserID;
                myTicketEntity.LastModifiedTime = myDBSetting.GetServerTime();
            }
            myTicketEntity.Save(UserID, "IN", saveAction, dtCopyApp);
            return bSave;
        }
        private bool SaveAtt()
        {
            bool bSaveAtt = true;
            if (CtlUpload.UploadedFiles[0] != null)
            {
                sFilePathName = HttpContext.Current.Session["UserID"].ToString() + Guid.NewGuid() + Path.GetExtension(CtlUpload.UploadedFiles[0].FileName);
                string sfilePath = MapPath(@"~/Upload/" + sFilePathName);
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
            if (string.IsNullOrEmpty(cbCategorySub.Text))
            {
                errorF = true;
                cbCategorySub.IsValid = false;
                cbCategorySub.ErrorText = "Value can't be empty.";
                if (!focusF)
                {
                    cbCategorySub.Focus();
                    focusF = true;
                    cplMain.JSProperties["cplblmessageError"] = "Sub Category, can't be empty.";
                    cplMain.JSProperties["cplActiveTabIndex"] = 1;
                }
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
            if (saveaction == SaveAction.Reject)
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
        protected void cplMain_Callback(object source, CallbackEventArgs e)
        {
            isValidLogin(false);
            string urlsave = "";
            string[] callbackParam = e.Parameter.ToString().Split(';');
            urlsave = "~/Transaction/TicketTrans/FormTicketMaint.aspx";
            var nameValues = HttpUtility.ParseQueryString(Request.QueryString.ToString());
            nameValues.Set("DocKey", myTicketEntity.DocKey.ToString());
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
                    bErrorLineSave = false;
                    cplMain.JSProperties["cplblmessageError"] = "";
                    cplMain.JSProperties["cplblmessage"] = "are you sure want to submit this ticket?";
                    cplMain.JSProperties["cplblActionButton"] = "SAVE";
                    if (ErrorInField(out strmessageError, SaveAction.Save))
                    {
                        cplMain.JSProperties["cplblmessageError"] = strmessageError;
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
                    Save(SaveAction.Save);
                    cplMain.JSProperties["cpAlertMessage"] = "Transaction has been save...";
                    cplMain.JSProperties["cplblActionButton"] = "SAVE";
                    DevExpress.Web.ASPxWebControl.RedirectOnCallback(urlsave + updatedQueryString);
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
                    if (!BCE.Data.Convert.TextToBoolean(myTicketEntity.Cancelled))
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
                    cplMain.JSProperties["cpDocKey"] = myTicketEntity.DocKey;
                    break;
            }
        }
        protected void cbCategory_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {

        }
        protected void cbCategory_DataBinding(object sender, EventArgs e)
        {
            (sender as ASPxComboBox).DataSource = myCategoryTable;
        }
        protected void cbCategorySub_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
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
        protected void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void UploadControl_FilesUploadComplete(object sender, FilesUploadCompleteEventArgs e)
        {
            //foreach (UploadedFile file in UploadControl.UploadedFiles)
            //{
            //    if (!string.IsNullOrEmpty(file.FileName) && file.IsValid)
            //        e.CallbackData = "success";
            //}
        }
        protected void btnDownload_Click(object sender, EventArgs e)
        {
            DownloadAtt();
        }
        protected void btnCloseWindow_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Transaction/TicketTrans/FormTicketMaint.aspx");
        }
    }
}