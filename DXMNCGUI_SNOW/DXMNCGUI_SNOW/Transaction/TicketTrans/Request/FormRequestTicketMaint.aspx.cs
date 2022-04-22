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
using System.Web.SessionState;
using System.Web.Security;
using System.ComponentModel;
using BCE.Data;

namespace DXMNCGUI_SNOW.Transaction.TicketTrans.Request
{
    public partial class FormRequestTicketMaint : BasePage
    {
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
        protected DataTable mytableSearch
        {
            get { isValidLogin(false); return (DataTable)HttpContext.Current.Session["mytableSearch" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["mytableSearch" + this.ViewState["_PageID"]] = value; }
        }
        protected DataTable mytableDetailSearch
        {
            get { isValidLogin(false); return (DataTable)HttpContext.Current.Session["mytableDetailSearch" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["mytableDetailSearch" + this.ViewState["_PageID"]] = value; }
        }
        protected TicketRequestDB myTicketRequestDB
        {
            get { isValidLogin(false); return (TicketRequestDB)HttpContext.Current.Session["myTicketRequestDB" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myTicketRequestDB" + this.ViewState["_PageID"]] = value; }
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.ViewState["_PageID"] = Guid.NewGuid();
                isValidLogin();
                myDBSetting = dbsetting;
                myDBSession = dbsession;
                mytableSearch = new DataTable();
                mytableDetailSearch = new DataTable();
                this.myTicketRequestDB = TicketRequestDB.Create(myDBSetting, dbsession);
                if (!accessright.IsAccessibleByUserID(UserID, "TICKET_VIEW_ALL"))
                {
                    mytableSearch = this.myTicketRequestDB.LoadBrowseTable(false, myDBSession.LoginUserID);
                }
                else
                {
                    mytableSearch = this.myTicketRequestDB.LoadBrowseTable(true, myDBSession.LoginUserID);
                }
                gvRequestList.DataBind();

                if (this.Request.QueryString["DocKey"] != null)
                {
                    int indexVal = gvRequestList.FindVisibleIndexByKeyValue(this.Request.QueryString["DocKey"]);
                    gvRequestList.FocusedRowIndex = indexVal;
                }
                else
                {
                    gvRequestList.FocusedRowIndex = -1;
                }
            }
        }
        protected void OpenData()
        {
            string updatedQueryString = "";
            try
            {
                DataRow myrow = gvRequestList.GetDataRow(gvRequestList.FocusedRowIndex);
                if (myrow != null)
                {
                    var nameValues = HttpUtility.ParseQueryString(Request.QueryString.ToString());
                    nameValues.Set("Key", this.ViewState["_PageID"].ToString());
                    updatedQueryString = "?" + nameValues.ToString();
                    myTicketRequestEntity = myTicketRequestDB.Grab(System.Convert.ToInt32(myrow["DocKey"]), TicketAction.Grab);
                    Response.Redirect("~/Transaction/TicketTrans/Request/FormRequestTicketEntry.aspx" + updatedQueryString);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "please select row first.." + "');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.Message + "');", true);
                return;
            }
            //Response.Redirect("~/Transaction/TicketTrans/Request/FormRequestTicketEntry.aspx" + updatedQueryString);
        }
        protected void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose();
        }
        protected void btnNew_Click(object sender, EventArgs e)
        {
            string updatedQueryString = "";
            try
            {
                myTicketRequestEntity = myTicketRequestDB.NewEntity(TicketType.RQ);
                var nameValues = HttpUtility.ParseQueryString(Request.QueryString.ToString());
                nameValues.Set("Key", this.ViewState["_PageID"].ToString());
                updatedQueryString = "?" + nameValues.ToString();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.Message + "');", true);
                return;
            }
            Response.Redirect("~/Transaction/TicketTrans/Request/FormRequestTicketEntry.aspx" + updatedQueryString);
        }
        protected void btnGrab_Click(object sender, EventArgs e)
        {
            OpenData();
        }
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                isValidLogin();
                if (!accessright.IsAccessibleByUserID(UserID, "TICKET_VIEW_ALL"))
                {
                    mytableSearch = this.myTicketRequestDB.LoadBrowseTable(false, myDBSession.LoginUserID);
                }
                else
                {
                    mytableSearch = this.myTicketRequestDB.LoadBrowseTable(true, myDBSession.LoginUserID);
                }
                gvRequestList.DataSource = mytableSearch;
                gvRequestList.DataBind();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.Message + "');", true);
                return;
            }
        }
        protected void gvRequestList_DataBinding(object sender, EventArgs e)
        {
            (sender as ASPxGridView).DataSource = mytableSearch;
        }
        protected void gvRequestList_FocusedRowChanged(object sender, EventArgs e)
        {

        }
        protected void gvRequestList_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            string updatedQueryString = "";
            ASPxGridView gridView = (ASPxGridView)sender;
            string[] callbackParam = e.Parameters.ToString().Split(';');
            (sender as ASPxGridView).JSProperties["cpNewWindowUrl"] = null;
            gvRequestList.JSProperties["cpCallbackParam"] = callbackParam[0].ToUpper();
            if (callbackParam.Length > 1)
            {
                object paramName = callbackParam[0].ToUpper();
                object paramValue = callbackParam[1].ToUpper();
                gridView.JSProperties["cplblmessageError"] = "";
                gridView.JSProperties["cplblActionButton"] = "";

                switch (callbackParam[0].ToUpper())
                {
                    case "INDEX":
                        int ivisibleindex = 0;
                        ivisibleindex = System.Convert.ToInt16(paramValue);
                        gvRequestList.JSProperties["cpVisibleIndex"] = ivisibleindex;
                        gridView.KeyFieldName = "TicketNo";
                        break;
                    case "OPEN":
                        break;
                    case "REFRESH":
                        try
                        {
                            isValidLogin();
                            if (!accessright.IsAccessibleByUserID(UserID, "TICKET_VIEW_ALL"))
                            {
                                mytableSearch = this.myTicketRequestDB.LoadBrowseTable(false, myDBSession.LoginUserID);
                            }
                            else
                            {
                                mytableSearch = this.myTicketRequestDB.LoadBrowseTable(true, myDBSession.LoginUserID);
                            }
                            gvRequestList.DataSource = mytableSearch;
                            gvRequestList.DataBind();
                        }
                        catch (Exception ex)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.Message + "');", true);
                            return;
                        }
                        break;
                    case "DOUBLECLICK":
                        try
                        {
                            DataRow myrow = gvRequestList.GetDataRow(gvRequestList.FocusedRowIndex);
                            if (myrow != null)
                            {
                                var nameValues = HttpUtility.ParseQueryString(Request.QueryString.ToString());
                                nameValues.Set("Key", this.ViewState["_PageID"].ToString());
                                updatedQueryString = "?" + nameValues.ToString();
                                myTicketRequestEntity = myTicketRequestDB.Grab(System.Convert.ToInt32(myrow["DocKey"]), TicketAction.Grab);
                                DevExpress.Web.ASPxWebControl.RedirectOnCallback("~/Transaction/TicketTrans/Request/FormRequestTicketEntry.aspx" + updatedQueryString);
                            }
                        }
                        catch (Exception ex)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.Message + "');", true);
                            return;
                        }
                        break;
                }
            }
        }
        protected void gvRequestList_CustomUnboundColumnData(object sender, DevExpress.Web.ASPxGridViewColumnDataEventArgs e)
        {

        }
        protected void gvRequestListDetail_DataBinding(object sender, EventArgs e)
        {
            (sender as ASPxGridView).DataSource = mytableDetailSearch;
        }
        protected void gvRequestListDetail_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            ASPxGridView gridView = (ASPxGridView)sender;
            string[] callbackParam = e.Parameters.ToString().Split(';');
            gridView.JSProperties["cpCallbackParam"] = callbackParam[0].ToUpper();
            object paramName = callbackParam[0].ToUpper();
            object paramValue = callbackParam[1].ToUpper();
            switch (callbackParam[0].ToUpper())
            {
                case "DETAILLOAD":
                    mytableDetailSearch = this.myTicketRequestDB.LoadBrowseTableDetail(paramValue.ToString());
                    gvRequestListDetail.DataBind();
                    break;
            }
        }
        protected void cplMain_Callback(object source, DevExpress.Web.CallbackEventArgs e)
        {

        }

        protected void gvRequestList_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != GridViewRowType.Data) return;
            if (e.GetValue("Status").ToString() == "OPEN")
                e.Row.ForeColor = System.Drawing.Color.Green;
            if (e.GetValue("Status").ToString() == "REJECT")
                e.Row.ForeColor = System.Drawing.Color.Red;
        }
    }
}