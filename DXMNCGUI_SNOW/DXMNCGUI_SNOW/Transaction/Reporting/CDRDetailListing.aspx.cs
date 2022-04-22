using DevExpress.Web;
using DXMNCGUI_SNOW.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DXMNCGUI_SNOW.Transaction.Reporting
{
    public partial class CDRDetailListing : BasePage
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
        protected DataTable myBrowseTable
        {
            get { isValidLogin(true); return (DataTable)HttpContext.Current.Session["myBrowseTable" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myBrowseTable" + this.ViewState["_PageID"]] = value; }
        }
        protected DataTable LoadBrowseTable(DateTime defrom, DateTime deto)
        {
            DataTable mytable = new DataTable();
            SqlConnection myconn = new SqlConnection(dbsetting.ConnectionString);
            using (SqlCommand cmd = new SqlCommand("[sp_listCDR]", myconn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter spStartDate = new SqlParameter("@start_date", defrom);
                spStartDate.SqlDbType = SqlDbType.DateTime;
                cmd.Parameters.Add(spStartDate);
                SqlParameter spEndDate = new SqlParameter("@end_date", deto);
                spEndDate.SqlDbType = SqlDbType.DateTime;
                cmd.Parameters.Add(spEndDate);
                adapter.Fill(mytable);
            }
            return mytable;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            isValidLogin(true);
            if (!Page.IsPostBack)
            {
                this.ViewState["_PageID"] = Guid.NewGuid();
                myDBSetting = dbsetting;
                myDBSession = dbsession;

                myBrowseTable = new DataTable();
                gvMain.DataSource = myBrowseTable;
                gvMain.DataBind();
            }
        }
        protected void cplMain_Callback(object source, DevExpress.Web.CallbackEventArgs e)
        {
            cplMain.JSProperties["cpType"] = "";
            string[] callbackParam = e.Parameter.ToString().Split(';');
            cplMain.JSProperties["cpCallbackParam"] = callbackParam[0].ToUpper();
            switch (callbackParam[0].ToUpper())
            {
                case "INQUIRY":
                    break;
            }
        }
        protected void gvMain_DataBinding(object sender, EventArgs e)
        {
            (sender as ASPxGridView).DataSource = myBrowseTable;
        }
        protected void gvMain_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            myBrowseTable = LoadBrowseTable(Convert.ToDateTime(deFrom.Value), Convert.ToDateTime(deTo.Value));
            gvMain.DataSource = myBrowseTable;
            gvMain.DataBind();        
        }
    }
}