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

namespace DXMNCGUI_SNOW.Transaction.TicketTrans.Request
{
    public partial class FormRequestTicketEntry : BasePage
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
        protected TicketRequestNewEntity myTicketRequestEntity
        {
            get { isValidLogin(false); return (TicketRequestNewEntity)HttpContext.Current.Session["myTicketRequestEntity" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myTicketRequestEntity" + this.ViewState["_PageID"]] = value; }
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
        protected TicketRequestDB myTicketRequestDB
        {
            get { isValidLogin(false); return (TicketRequestDB)HttpContext.Current.Session["myTicketRequestDB" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myTicketRequestDB" + this.ViewState["_PageID"]] = value; }
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
                    this.myTicketRequestDB = TicketRequestDB.Create(myDBSetting, myDBSession);
                    myTicketRequestEntity = this.myTicketRequestDB.View(BCE.Data.Convert.ToInt32(this.Request.QueryString["SourceKey"]));
                }
                myheadertable = new DataTable();
                myCategoryTable = new DataTable();
                myCategorySubTable = new DataTable();
                myDocNoFormatTable = new DataTable();
                mySectionTable = new DataTable();
                strDocName = "";
                igridindex = -1;
                bPreviewDocument = false;
                iLineID = -1;
                myds = new DataSet();
                this.myTicketRequestDB = TicketRequestDB.Create(myDBSetting, myDBSession);
                strKey = Request.QueryString["Key"];
                SetTicket((TicketRequestNewEntity)HttpContext.Current.Session["myTicketRequestEntity" + strKey]);
            }
            if (!IsCallback)
            {

            }
        }
        private void SetTicket(TicketRequestNewEntity newTicketRequestEntity)
        {
            if (this.myTicketRequestEntity != newTicketRequestEntity)
            {
                if (newTicketRequestEntity != null)
                {
                    this.myTicketRequestEntity = newTicketRequestEntity;
                }
                myAction = this.myTicketRequestEntity.Action;
                myDocType = this.myTicketRequestEntity.DocType;
                myds = myTicketRequestEntity.myDataSet;
                myStatus = this.myTicketRequestEntity.Status.ToString();
                sFilePathName = this.myTicketRequestEntity.Attachment.ToString();
                myheadertable = myds.Tables[0];
                setuplookupedit();
                BindingMaster();
                Accessable();
                if (myTicketRequestEntity.Category.ToString().ToUpper() == "USER ADMINISTRATION")
                {
                    MainLayout.FindItemOrGroupByName("lgUserAdmin").ClientVisible = true;
                }
            }
        }
        private void setuplookupedit()
        {
            if (myTicketRequestEntity != null)
            {
                DataView dv = new DataView(myTicketRequestEntity.LoadDocNoFormatTable());
                myDocNoFormatTable = dv.ToTable();
                myCategoryTable = myTicketRequestEntity.LoadCategoryTable();
                cbCategory.DataSource = myCategoryTable;
                cbCategory.DataBind();
                FillCategorySub(myTicketRequestEntity.Category.ToString());
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
                MainLayout.FindItemOrGroupByName("lgMain").Caption = "New Ticket Entry";
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
                MainLayout.FindItemOrGroupByName("lgMain").Caption = "Grab / Close Ticket";
                MainLayout.FindItemOrGroupByName("lytBtnOverWrite").ClientVisible = true;
                bReadOnly = true;
                bEnable = false;
                bCancel = false;
                bGrab = true;
                bReject = true;
                bOnHold = false;
                bVisible = true;

                if (myTicketRequestEntity.Status.ToString() == "OPEN")
                {
                    mmReason.BackColor = Greycolor;
                    mmReason.Visible = false;
                    mmReason.Enabled = false;
                }
                if (myTicketRequestEntity.Status.ToString() == "ON PROGRESS")
                {
                    btnGrab.Text = "Complete";
                    mmReason.BackColor = Whitecolor;
                    mmReason.Visible = true;
                    mmReason.Enabled = true;
                    btnOnHold.Enabled = true;
                }
                if (myTicketRequestEntity.Status.ToString() == "CLOSE")
                {
                    MainLayout.FindItemOrGroupByName("lytBtnOverWrite").ClientVisible = false;

                    btnGrab.Enabled = false;
                    btnReject.Enabled = false;
                    btnOnHold.Enabled = false;

                    mmReason.BackColor = Greycolor;
                    mmReason.Visible = true;
                    mmReason.Enabled = false;
                }
                if (myTicketRequestEntity.Status.ToString() == "REJECT")
                {
                    btnGrab.Enabled = false;
                    btnReject.Enabled = false;
                    btnOnHold.Enabled = false;

                    mmReason.BackColor = Greycolor;
                    mmReason.Visible = true;
                    mmReason.Enabled = false;
                }
                if (myTicketRequestEntity.Status.ToString() == "ON HOLD")
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
                MainLayout.FindItemOrGroupByName("lgMain").Caption = "View Ticket";
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

            chkEmail.ReadOnly = bReadOnly;
            chkFilezilla.ReadOnly = bReadOnly;
            chkPcLogin.ReadOnly = bReadOnly;
            chkPin.ReadOnly = bReadOnly;
            chkSMILE.ReadOnly = bReadOnly;

            cbCategory.ReadOnly = bReadOnly;
            cbCategory.ForeColor = System.Drawing.Color.Black;
            cbCategory.BackColor = MandatoryColor;

            cbCategorySub.ReadOnly = bReadOnly;
            cbCategorySub.ForeColor = System.Drawing.Color.Black;
            cbCategorySub.BackColor = MandatoryColor;

            mmDescription.ReadOnly = bReadOnly;
            mmDescription.ForeColor = System.Drawing.Color.Black;
            mmDescription.BackColor = MandatoryColor;

            mmDescription2.ReadOnly = bReadOnly;
            mmDescription2.ForeColor = System.Drawing.Color.Black;
            mmDescription2.BackColor = MandatoryColor;

            mmReason.ForeColor = System.Drawing.Color.Black;
            mmReason.BackColor = MandatoryColor;

            CtlUpload.ClientEnabled = bEnable;
            CtlUpload.ForeColor = System.Drawing.Color.Black;
            CtlUpload.BackColor = MandatoryColor;

            if (myTicketRequestEntity.Attachment.ToString().Length > 0)
                btnDownload.ClientVisible = bVisible;

            if (myAction != TicketAction.New)
            {
                if (accessright.IsAccessibleByUserID(UserID, "TICKET_CAN_GRAB"))
                {
                    btnGrab.ClientEnabled = true;
                    btnReject.ClientEnabled = true;
                    btnOnHold.ClientEnabled = true;

                    if (myTicketRequestEntity.Status.ToString() == "REJECT" || myTicketRequestEntity.Status.ToString() == "CLOSE")
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

            if (myAction == TicketAction.New || myTicketRequestEntity.Status.ToString() == "OPEN")
            {
                MainLayout.FindItemOrGroupByName("LayoutItemReason").Caption = "";
                mmReason.Visible = false;
                mmReason.BackColor = Greycolor;

                if (accessright.IsAccessibleByUserID(UserID, "TICKET_CAN_GRAB") && myAction != TicketAction.New)
                {

                }
            }

            if (myTicketRequestEntity.Status.ToString() != "CLOSE" && accessright.IsAccessibleByUserID(UserID, "TICKET_CAN_GRAB"))
            {
                cbCategory.ReadOnly = false;
                cbCategorySub.ReadOnly = false;

                cbCategory.BackColor = Whitecolor;
                cbCategorySub.BackColor = Whitecolor;

                chkEmail.ReadOnly = false;
                chkFilezilla.ReadOnly = false;
                chkPcLogin.ReadOnly = false;
                chkPin.ReadOnly = false;
                chkSMILE.ReadOnly = false;
            }
        }
        private void BindingMaster()
        {
            txtTicketNo.Text = myTicketRequestEntity.TicketNo.ToString();
            txtStatus.Text = myTicketRequestEntity.Status.ToString();
            deReqDate.Value = myTicketRequestEntity.TicketReqDate;
            cbCategory.Value = myTicketRequestEntity.Category;
            cbCategorySub.Value = myTicketRequestEntity.SubCategory;
            mmDescription.Text = myTicketRequestEntity.Description.ToString();
            mmDescription2.Text = myTicketRequestEntity.Description2.ToString();
            mmReason.Text = myTicketRequestEntity.Reason.ToString();
            chkEmail.CheckState = myTicketRequestEntity.Email.ToString() == "T" ? CheckState.Checked : CheckState.Unchecked;
            chkPcLogin.CheckState = myTicketRequestEntity.PcLogin.ToString() == "T" ? CheckState.Checked : CheckState.Unchecked;
            chkSMILE.CheckState = myTicketRequestEntity.SMILE.ToString() == "T" ? CheckState.Checked : CheckState.Unchecked;
            chkFilezilla.CheckState = myTicketRequestEntity.FileZilla.ToString() == "T" ? CheckState.Checked : CheckState.Unchecked;
            chkPin.CheckState = myTicketRequestEntity.PINtlp.ToString() == "T" ? CheckState.Checked : CheckState.Unchecked;
        }
        protected void FillCategorySub(string strcategory)
        {
            if (string.IsNullOrEmpty(strcategory)) return;
            myCategorySubTable.Clear();
            myCategorySubTable = myTicketRequestEntity.LoadCategorySubTable(strcategory);
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

            myTicketRequestEntity.TicketNo = txtTicketNo.Value;
            myTicketRequestEntity.TicketReqDate = deReqDate.Value;
            myTicketRequestEntity.Category = cbCategory.Value;
            myTicketRequestEntity.SubCategory = cbCategorySub.Value;
            myTicketRequestEntity.Description = mmDescription.Value;
            myTicketRequestEntity.Description2 = mmDescription2.Value;
            myTicketRequestEntity.Reason = mmReason.Value;
            myTicketRequestEntity.Attachment = sFilePathName;
            myTicketRequestEntity.LastModifiedUser = UserID;
            myTicketRequestEntity.Email = chkEmail.CheckState           == CheckState.Checked ? "T" : "F";
            myTicketRequestEntity.PcLogin = chkPcLogin.CheckState       == CheckState.Checked ? "T" : "F";
            myTicketRequestEntity.SMILE = chkSMILE.CheckState           == CheckState.Checked ? "T" : "F";
            myTicketRequestEntity.FileZilla = chkFilezilla.CheckState   == CheckState.Checked ? "T" : "F";
            myTicketRequestEntity.PINtlp = chkPin.CheckState            == CheckState.Checked ? "T" : "F";
            if (myAction == TicketAction.New)
            {
                myTicketRequestEntity.CreatedUserID = UserID;
                myTicketRequestEntity.CreatedTimeStamp = myDBSetting.GetServerTime();
            }
            myTicketRequestEntity.LastModifiedTime = myDBSetting.GetServerTime();

            if (saveAction == SaveAction.Save)
            {
                myTicketRequestEntity.Status = "OPEN";
            }
            else if (saveAction == SaveAction.Grab)
            {
                myTicketRequestEntity.Status = "ON PROGRESS";
                myTicketRequestEntity.LastModifiedUser = UserID;
                myTicketRequestEntity.LastModifiedTime = myDBSetting.GetServerTime();
                myTicketRequestEntity.GrabByUser = UserID;
                myTicketRequestEntity.GrabDate = myDBSetting.GetServerTime();
            }
            else if (saveAction == SaveAction.Reject)
            {
                myTicketRequestEntity.Status = "REJECT";
                myTicketRequestEntity.LastModifiedUser = UserID;
                myTicketRequestEntity.LastModifiedTime = myDBSetting.GetServerTime();
            }
            else if (saveAction == SaveAction.OnHold)
            {
                myTicketRequestEntity.Status = "ON HOLD";
                myTicketRequestEntity.LastModifiedUser = UserID;
                myTicketRequestEntity.LastModifiedTime = myDBSetting.GetServerTime();
            }
            else if (saveAction == SaveAction.Close)
            {
                myTicketRequestEntity.Status = "CLOSE";
                myTicketRequestEntity.LastModifiedUser = UserID;
                myTicketRequestEntity.LastModifiedTime = myDBSetting.GetServerTime();
                myTicketRequestEntity.CloseByUser = UserID;
                myTicketRequestEntity.CloseDate = myDBSetting.GetServerTime();
            }
            else if (saveAction == SaveAction.OverWrite)
            {
                myTicketRequestEntity.LastModifiedUser = UserID;
                myTicketRequestEntity.LastModifiedTime = myDBSetting.GetServerTime();
            }
            myTicketRequestEntity.Save(UserID, "RQ", saveAction, dtCopyApp);
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
        protected void cplMain_Callback(object source, DevExpress.Web.CallbackEventArgs e)
        {
            isValidLogin(false);
            string urlsave = "";
            string[] callbackParam = e.Parameter.ToString().Split(';');
            urlsave = "~/Transaction/TicketTrans/Request/FormRequestTicketMaint.aspx";
            var nameValues = HttpUtility.ParseQueryString(Request.QueryString.ToString());
            nameValues.Set("DocKey", myTicketRequestEntity.DocKey.ToString());
            string updatedQueryString = "?" + nameValues.ToString();
            cplMain.JSProperties["cpCallbackParam"] = callbackParam[0].ToUpper();
            cplMain.JSProperties["cpVisible"] = null;
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
                    cplMain.JSProperties["cpVisible"] = null;
                    if (paramValue.ToString().ToUpper() == "USER ADMINISTRATION")
                    {
                        cplMain.JSProperties["cpVisible"] = true;
                    }
                    else
                    {
                        cplMain.JSProperties["cpVisible"] = false;
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
                    if (!BCE.Data.Convert.TextToBoolean(myTicketRequestEntity.Cancelled))
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
                    cplMain.JSProperties["cpDocKey"] = myTicketRequestEntity.DocKey;
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
        protected void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

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
        protected void btnDownload_Click(object sender, EventArgs e)
        {
            DownloadAtt();
        }
        protected void btnCloseWindow_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Transaction/TicketTrans/Request/FormRequestTicketMaint.aspx");
        }
    }
}