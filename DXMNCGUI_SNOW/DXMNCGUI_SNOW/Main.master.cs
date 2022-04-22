using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Security;
using DXMNCGUI_SNOW.Controllers;
using System.Web.Configuration;
using DevExpress.Web;
using System.Data.SqlClient;
using System.Web.Caching;

namespace DXMNCGUI_SNOW
{
    public partial class MainMaster : System.Web.UI.MasterPage
    {
        protected SqlDBSetting myDBSetting
        {
            get { return (SqlDBSetting)HttpContext.Current.Session["HomeSqlDBSetting" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["HomeSqlDBSetting" + this.ViewState["_PageID"]] = value; }
        }
        protected SqlDBSession myDBSession
        {
            get { return (SqlDBSession)HttpContext.Current.Session["HomeSqlDBSession" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["HomeSqlDBSession" + this.ViewState["_PageID"]] = value; }
        }
        protected DataTable mytable
        {
            get { return (DataTable)HttpContext.Current.Session["mytable" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["mytable" + this.ViewState["_PageID"]] = value; }
        }
        protected DataTable myparenttable
        {
            get { return (DataTable)HttpContext.Current.Session["myparenttable" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myparenttable" + this.ViewState["_PageID"]] = value; }
        }
        protected AccesRight accessright
        {
            get { return (AccesRight)HttpContext.Current.Session["accessright"]; }
            set { HttpContext.Current.Session["accessright"] = value; }
        }
        protected string UserID
        {
            get { return (string)HttpContext.Current.Session["UserID"]; }
            set { HttpContext.Current.Session["UserID"] = value; }
        }
        protected int icountNewTicket
        {
            get { return (int)HttpContext.Current.Session["icountNewTicket"]; }
            set { HttpContext.Current.Session["icountNewTicket"] = value; }
        }
        protected DataTable myIncidentTbl
        {
            get { return (DataTable)HttpContext.Current.Session["myIncidentTbl"]; }
            set { HttpContext.Current.Session["myIncidentTbl"] = value; }
        }

        public object MessageBox { get; private set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {                
                mytable = new DataTable();
                myparenttable = new DataTable();
                myIncidentTbl = new DataTable();
                if (HttpContext.Current.Session["SessionID"] == null)
                {
                    HttpContext.Current.Session.Abandon();
                    FormsAuthentication.SignOut();
                    Response.Redirect("~/Account/Login.aspx");
                }
                myDBSetting = (SqlDBSetting)HttpContext.Current.Session["SqlDBSetting"];
                myDBSession = (SqlDBSession)HttpContext.Current.Session["SqlDBSession"];
                               
                if (!accessright.IsAccessibleByUserID(UserID, "GENERAL_MNTC_SHOW"))
                {
                    ASPxNavBar1.Groups.FindByName("nbgGeneralMaintenance").Visible = false;
                    ASPxNavBar1.Groups.FindByName("nbgReporting").Visible = false;                    
                }

                if (accessright.IsAccessibleByUserID(UserID, "TICKET_CAN_GRAB") && accessright.IsAccessibleByUserID(UserID, "TICKET_VIEW_ALL"))
                {
                    icountNewTicket = 0;
                    icountNewTicket = Convert.ToInt32(myDBSetting.ExecuteScalar("SELECT COUNT(*) FROM [dbo].[IncidentList] WHERE Status=?", "OPEN"));
                    if (icountNewTicket > 0)
                    {
                        ASPxNavBar1.Groups.FindByName("nbgTicketMenu").Items.FindByName("MenuIncident").Text += " " + "(" + icountNewTicket + ")";
                    }
                    icountNewTicket = Convert.ToInt32(myDBSetting.ExecuteScalar("SELECT COUNT(*) FROM [dbo].[RequestList] WHERE Status=?", "OPEN"));
                    if (icountNewTicket > 0)
                    {
                        ASPxNavBar1.Groups.FindByName("nbgTicketMenu").Items.FindByName("MenuRequest").Text += " " + "(" + icountNewTicket + ")";
                    }
                    icountNewTicket = Convert.ToInt32(myDBSetting.ExecuteScalar("SELECT COUNT(*) FROM [dbo].[ChangeDataList] WHERE Status=?", "APPROVE"));
                    if (icountNewTicket > 0)
                    {
                        ASPxNavBar1.Groups.FindByName("nbgTicketMenu").Items.FindByName("MenuCDR").Text += " " + "(" + icountNewTicket + ")";
                    }
                }
            }
        }
    }
}