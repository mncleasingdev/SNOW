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
using DXMNCGUI_SNOW.Transaction.TicketTrans.ChangeDataRequest;
using DXMNCGUI_SNOW.Transaction.TicketTrans;

namespace DXMNCGUI_SNOW.Transaction.WorkingList
{
    public partial class FormWorkingListMaint : BasePage
    {
        string SqlQuery = string.Empty;
        protected SqlDBSetting myDBSetting
        {
            get { isValidLogin(true); return (SqlDBSetting)HttpContext.Current.Session["HomeSqlDBSetting" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["HomeSqlDBSetting" + this.ViewState["_PageID"]] = value; }
        }
        protected SqlDBSession myDBSession
        {
            get { isValidLogin(false); return (SqlDBSession)HttpContext.Current.Session["myDBSession" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myDBSession" + this.ViewState["_PageID"]] = value; }
        }
        protected DataTable myWorklisttable
        {
            get { isValidLogin(true); return (DataTable)HttpContext.Current.Session["myWorklisttable" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myWorklisttable" + this.ViewState["_PageID"]] = value; }
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
        protected TicketChangeDataRequestDB myTicketChangeDataRequestDB
        {
            get { isValidLogin(true); return (TicketChangeDataRequestDB)HttpContext.Current.Session["myTicketChangeDataRequestDB" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myTicketChangeDataRequestDB" + this.ViewState["_PageID"]] = value; }
        }
        protected TicketChangeDataRequestEntity myTicketChangeDataRequestEntity
        {
            get { isValidLogin(true); return (TicketChangeDataRequestEntity)HttpContext.Current.Session["myTicketChangeDataRequestEntity" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myTicketChangeDataRequestEntity" + this.ViewState["_PageID"]] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            isValidLogin(true);
            if (!Page.IsPostBack)
            {
                this.ViewState["_PageID"] = Guid.NewGuid();
                myDBSetting = dbsetting;
                myDBSession = dbsession;
                myWorklisttable = new DataTable();
                myWorklisttable = LoadWorkListTable(dbsession.LoginUserID);
                gvWorkingList.DataSource = myWorklisttable;
                gvWorkingList.DataBind();
                iWorklistID = -1;
                iVisibleIndex = -1;
                if (Request.QueryString["Page"] != null)
                {
                    string strPage = "";
                    strPage = Request.QueryString["Page"].ToString();
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Access denied to open " + strPage + "...');", true);
                }
                if (this.Request.QueryString["Source"] != null)
                {
                    int indexVal = gvWorkingList.FindVisibleIndexByKeyValue(this.Request.QueryString["Source"]);
                    gvWorkingList.FocusedRowIndex = indexVal;
                }
                else
                {
                    gvWorkingList.FocusedRowIndex = -1;
                }

            }
        }
        protected DataTable LoadWorkListTable(string strUserID)
        {
            DataTable mytable = new DataTable();
            SqlConnection myconn = new SqlConnection(myDBSetting.ConnectionString);
            SqlQuery = "SELECT *, WorkList.SubmitByID + ' - ' + (select FULLNAME from Users WHERE NIK=WorkList.SubmitByID) as FULLNAME FROM Worklist WHERE NeedApproveByID=@NeedApproveByID\n";
            using (SqlCommand cmdheader = new SqlCommand(SqlQuery, myconn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmdheader);
                cmdheader.CommandType = CommandType.Text;
                cmdheader.Parameters.Add("@NeedApproveByID", SqlDbType.NVarChar);
                cmdheader.Parameters["@NeedApproveByID"].Value = strUserID;
                adapter.Fill(mytable);
            }
            return mytable;
        }
        protected void gvWorkingList_DataBinding(object sender, EventArgs e)
        {

        }
        protected void gvWorkingList_FocusedRowChanged(object sender, EventArgs e)
        {

        }
        protected void gvWorkingList_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            string[] callbackParam = e.Parameters.ToString().Split(';');
            (sender as ASPxGridView).JSProperties["cpCallbackParam"] = callbackParam[0].ToUpper();
            object paramName = callbackParam[0].ToUpper();
            object paramValue = callbackParam[1].ToUpper();
            switch (callbackParam[0].ToUpper())
            {
                case "INDEX":
                    iVisibleIndex = System.Convert.ToInt16(paramValue);
                    (sender as ASPxGridView).JSProperties["cpVisibleIndex"] = iVisibleIndex;
                    object obj = (sender as ASPxGridView).GetRowValues(iVisibleIndex, "ID");
                    if (obj != null && obj != DBNull.Value)
                    {
                        iWorklistID = System.Convert.ToInt32(obj);
                    }
                    break;
                case "REFRESH":
                    try
                    {
                        isValidLogin();
                        myWorklisttable = LoadWorkListTable(dbsession.LoginUserID);
                        gvWorkingList.DataSource = myWorklisttable;
                        gvWorkingList.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.Message + "');", true);
                        return;
                    }
                    break;
            }
        }
        protected void gvWorkingList_CustomUnboundColumnData(object sender, DevExpress.Web.ASPxGridViewColumnDataEventArgs e)
        {

        }
        protected void cplMain_Callback(object source, DevExpress.Web.CallbackEventArgs e)
        {
            string updatedQueryString = "";
            cplMain.JSProperties["cpType"] = "";
            long docKey = -1;
            string strType = "";
            string[] callbackParam = e.Parameter.ToString().Split(';');
            cplMain.JSProperties["cpCallbackParam"] = callbackParam[0].ToUpper();
            strType = callbackParam[2].ToString();
            switch (callbackParam[0].ToUpper())
            {
                case "APPROVAL":
                    bool validF = false;
                    try
                    {
                        cplMain.JSProperties["cpType"] = strType;
                        if (strType.Contains("CD"))
                        {
                            if (myDBSetting.ExecuteScalar("SELECT DocKey FROM ChangeDataList WHERE DocKey=? AND UPPER(Status) <> 'COMPLETE'", BCE.Data.Convert.ToInt64(callbackParam[1])) == null) return;
                            docKey = BCE.Data.Convert.ToInt64(myDBSetting.ExecuteScalar("SELECT DocKey FROM ChangeDataList WHERE DocKey=? AND UPPER(Status)<>'COMPLETE'", BCE.Data.Convert.ToInt64(callbackParam[1])));
                            if (docKey > 0)
                            {
                                validF = true;
                                try
                                {                                   
                                    var nameValues = HttpUtility.ParseQueryString(Request.QueryString.ToString());
                                    nameValues.Set("Key", this.ViewState["_PageID"].ToString());
                                    updatedQueryString = "?" + nameValues.ToString();
                                    myTicketChangeDataRequestDB = TicketChangeDataRequestDB.Create(myDBSetting, dbsession);
                                    myTicketChangeDataRequestEntity = myTicketChangeDataRequestDB.Approve(docKey, TicketAction.Approve);
                                    ASPxWebControl.RedirectOnCallback("~/Transaction/TicketTrans/ChangeDataRequest/FormTicketChangeDataRequestEntry.aspx" + updatedQueryString);
                                }
                                catch (Exception ex)
                                {
                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.Message + "');", true);
                                    return;
                                }
                                break;
                            }
                        }
                        else
                        {
                            
                        }
                    }
                    catch (Exception ex)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.Message + "');", true);
                        validF = false;
                    }
                    cplMain.JSProperties["cpValidF"] = validF;
                    cplMain.JSProperties["cpDocKey"] = docKey;
                    break;
            }
        }
        protected void gvWorkingList_CustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            if (e.ButtonID == "btnShow")
            {
                try
                {
                    DataRow myrow = (sender as ASPxGridView).GetDataRow((sender as ASPxGridView).FocusedRowIndex);
                    if (myrow != null)
                    {
                        object obj = (sender as ASPxGridView).GetRowValues(e.VisibleIndex, "ID");
                        if (obj != null && obj != DBNull.Value)
                        {
                            iWorklistID = System.Convert.ToInt32(obj);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.Message + "');", true);
                    return;
                }
            }
        }
    }
}