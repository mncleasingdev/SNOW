using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DXMNCGUI_SNOW.Controllers;
using System.Security;
using System.Web.Security;
using DevExpress.Web;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.ComponentModel;
using System.Web.Services;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.Script.Services;
using DXMNCGUI_SNOW.Transaction.TicketTrans;
using System.IO;

namespace DXMNCGUI_SNOW {
    public partial class _Default : BasePage
    {
        string SqlQuery = string.Empty;

        protected SqlDBSetting myDBSetting
        {
            get { isValidLogin(true); return (SqlDBSetting)HttpContext.Current.Session["HomeSqlDBSetting" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["HomeSqlDBSetting" + this.ViewState["_PageID"]] = value; }
        }
        protected DataTable myIncidentListtable
        {
            get { isValidLogin(true); return (DataTable)HttpContext.Current.Session["myIncidentListtable" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myIncidentListtable" + this.ViewState["_PageID"]] = value; }
        }
        protected DataTable myWorklist2table
        {
            get { isValidLogin(true); return (DataTable)HttpContext.Current.Session["myWorklist2table" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myWorklist2table" + this.ViewState["_PageID"]] = value; }
        }
        protected DataTable myWorklist3table
        {
            get { isValidLogin(true); return (DataTable)HttpContext.Current.Session["myWorklist3table" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myWorklist3table" + this.ViewState["_PageID"]] = value; }
        }
        protected DataTable myWorklist4table
        {
            get { isValidLogin(true); return (DataTable)HttpContext.Current.Session["myWorklist4table" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myWorklist4table" + this.ViewState["_PageID"]] = value; }
        }
        protected DataTable myWhosHappyTodaytable
        {
            get { isValidLogin(true); return (DataTable)HttpContext.Current.Session["myWhosHappyTodaytable" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myWhosHappyTodaytable" + this.ViewState["_PageID"]] = value; }
        }
        protected DataTable myAttendenceLogtable
        {
            get { isValidLogin(true); return (DataTable)HttpContext.Current.Session["myAttendenceLogtable" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myAttendenceLogtable" + this.ViewState["_PageID"]] = value; }
        }
        protected DataTable myAttendenceLogtable2
        {
            get { isValidLogin(true); return (DataTable)HttpContext.Current.Session["myAttendenceLogtable2" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myAttendenceLogtable2" + this.ViewState["_PageID"]] = value; }
        }
        protected DataTable myContracttable
        {
            get { isValidLogin(true); return (DataTable)HttpContext.Current.Session["myContracttable" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myContracttable" + this.ViewState["_PageID"]] = value; }
        }
        protected DataTable myNewstable
        {
            get { isValidLogin(true); return (DataTable)HttpContext.Current.Session["myNewstable" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myNewstable" + this.ViewState["_PageID"]] = value; }
        }
        protected DataTable myBosstable
        {
            get { isValidLogin(true); return (DataTable)HttpContext.Current.Session["myBosstable" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myBosstable" + this.ViewState["_PageID"]] = value; }
        }
        protected Int32 iVisibleIndex
        {
            get { isValidLogin(true); return (Int32)HttpContext.Current.Session["iVisibleIndex" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["iVisibleIndex" + this.ViewState["_PageID"]] = value; }
        }
        protected Int32 iWorklistID
        {
            get { isValidLogin(true); return (Int32)HttpContext.Current.Session["iWorklistID" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["iWorklistID" + this.ViewState["_PageID"]] = value; }
        }
        protected SqlDBSession myDBSession
        {
            get { isValidLogin(false); return (SqlDBSession)HttpContext.Current.Session["myDBSession" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myDBSession" + this.ViewState["_PageID"]] = value; }
        }
        protected bool myViewAll
        {
            get { isValidLogin(false); return (bool)HttpContext.Current.Session["myViewAll" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myViewAll" + this.ViewState["_PageID"]] = value; }
        }
        protected DataTable mytableSearch
        {
            get { isValidLogin(false); return (DataTable)HttpContext.Current.Session["mytableSearch" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["mytableSearch" + this.ViewState["_PageID"]] = value; }
        }
        protected TicketNewEntity myTicketNewEntity
        {
            get { isValidLogin(false); return (TicketNewEntity)HttpContext.Current.Session["myTicketNewEntity" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myTicketNewEntity" + this.ViewState["_PageID"]] = value; }
        }
        protected TicketDB myTicketDB
        {
            get { isValidLogin(false); return (TicketDB)HttpContext.Current.Session["myTicketDB" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myTicketDB" + this.ViewState["_PageID"]] = value; }
        }
        protected string UserFullName
        {
            get { return (string)HttpContext.Current.Session["UserID"]; }
            set { HttpContext.Current.Session["UserID"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            isValidLogin(true);
            if (!Page.IsPostBack)
            {
                this.ViewState["_PageID"] = Guid.NewGuid();
                myDBSetting = dbsetting;
                myDBSession = dbsession;
                this.myTicketDB = TicketDB.Create(myDBSetting, myDBSession);

                myIncidentListtable = LoadIncidentListTable(dbsession.LoginUserID);
            }
        }

        protected DataTable LoadIncidentListTable(string strUserID)
        {
            DataTable mytable = new DataTable();
            SqlConnection myconn = new SqlConnection(myDBSetting.ConnectionString);
            if (dbsession.LoginUserID != "1907023")
            {
                SqlQuery = "select * from [dbo].[IncidentList] where CreatedUserID=@NIK";
            }
            else
            {
                SqlQuery = "select * from [dbo].[IncidentList]";
            }

            using (SqlCommand cmdheader = new SqlCommand(SqlQuery, myconn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmdheader);
                cmdheader.CommandType = CommandType.Text;
                cmdheader.Parameters.Add("@NIK", SqlDbType.NVarChar);
                cmdheader.Parameters["@NIK"].Value = dbsession.LoginUserID;
                adapter.Fill(mytable);
            }
            return mytable;
        }

        protected void gvWorkList_DataBinding(object sender, EventArgs e)
        {
            
        }

        protected void gvWorkList_FocusedRowChanged(object sender, EventArgs e)
        {

        }

        protected void gvWorkList_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void cplMain_Callback(object source, CallbackEventArgs e)
        {
            string[] callbackParam = e.Parameter.ToString().Split(';');

            switch (callbackParam[0].ToUpper())
            {
                case "NEW":
                    try
                    {
                    }
                    catch (Exception ex)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.Message + "');", true);
                        return;
                    }
                    break;
            }
        }

        protected void gvIncidentList_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            ASPxGridView gridView = (ASPxGridView)sender;
            object obj;
            string[] callbackParam = e.Parameters.ToString().Split(';');
            gridView.JSProperties["cpCallbackParam"] = callbackParam[0].ToUpper();
            object paramName = callbackParam[0].ToUpper();
            object paramValue = callbackParam[1].ToUpper();

            switch (callbackParam[0].ToUpper())
            {
                case "INDEX":
                    int ivisibleindex = 0;
                    ivisibleindex = System.Convert.ToInt16(paramValue);
                    gridView.JSProperties["cpVisibleIndex"] = ivisibleindex;
                    break;
                case "NEWENTRY":
                    try
                    {
                    }
                    catch (Exception ex)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.Message + "');", true);
                        return;
                    }
                    break;
                case "REFRESH":
                    mytableSearch = myTicketDB.LoadBrowseTable(myViewAll, UserID.ToString());
                    gridView.DataSource = mytableSearch;
                    gridView.DataBind();
                    gridView.KeyFieldName = "DocKey";
                    break;
                case "EDIT":
                    try
                    {

                    }
                    catch (Exception ex)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.Message + "');", true);
                        return;
                    }
                    break;
                case "VIEW":
                    try
                    {
                        obj = gridView.GetRowValues(BCE.Data.Convert.ToInt32(paramValue), gridView.KeyFieldName);
                        if (obj != null)
                        {
                            myTicketNewEntity = myTicketDB.View(BCE.Data.Convert.ToInt32(obj));
                            string url = "~/Transactions/CutiTrans/CutiTransEntry.aspx";
                            var nameValues = HttpUtility.ParseQueryString(Request.QueryString.ToString());
                            nameValues.Set("Key", this.ViewState["_PageID"].ToString());
                            string updatedQueryString = "?" + nameValues.ToString();
                            gridView.JSProperties["cplblmessageError"] = "";
                            if (!accessright.IsAccessible("300_4_REQPERMIT/LEAVE_TRANS_VIEW"))
                            {
                                gridView.JSProperties["cplblmessageError"] = "Access Denied! , Please Contact your Administrator... ";
                            }
                            else
                                DevExpress.Web.ASPxWebControl.RedirectOnCallback(url + updatedQueryString);
                        }
                    }
                    catch (Exception ex)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.Message + "');", true);
                        return;
                    }
                    break;
                case "PRINT":
                    try
                    {
                        gridView.JSProperties["cplDocKey"] = "";
                        gridView.JSProperties["cplRequestGroup"] = "";
                        obj = gridView.GetRowValues(BCE.Data.Convert.ToInt32(paramValue), gridView.KeyFieldName);
                        if (obj != null)
                        {
                            Int32 iDocKey = BCE.Data.Convert.ToInt32(obj);
                            gridView.JSProperties["cplDocKey"] = iDocKey;
                            obj = myDBSetting.ExecuteScalar("select RequestGroup from sch_cutitrans where dockey=?", BCE.Data.Convert.ToInt32(obj));
                            if (obj != null && obj != DBNull.Value)
                            {
                                gridView.JSProperties["cplRequestGroup"] = obj.ToString();
                            }
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
}