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

namespace DXMNCGUI_SNOW.Transaction.Chart
{
    public partial class iTicketReporting : BasePage
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
        protected DataTable myMaintable
        {
            get { isValidLogin(true); return (DataTable)HttpContext.Current.Session["myMaintable" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myMaintable" + this.ViewState["_PageID"]] = value; }
        }
        protected DataTable myINtable
        {
            get { isValidLogin(true); return (DataTable)HttpContext.Current.Session["myINtable" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myINtable" + this.ViewState["_PageID"]] = value; }
        }
        protected DataTable myRQtable
        {
            get { isValidLogin(true); return (DataTable)HttpContext.Current.Session["myRQtable" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myRQtable" + this.ViewState["_PageID"]] = value; }
        }
        protected DataTable myCDRtable
        {
            get { isValidLogin(true); return (DataTable)HttpContext.Current.Session["myCDRtable" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myCDRtable" + this.ViewState["_PageID"]] = value; }
        }
        protected DateTime myDate
        {
            get { isValidLogin(true); return (DateTime)HttpContext.Current.Session["myDate" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["myDate" + this.ViewState["_PageID"]] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            isValidLogin(true);
            if (!Page.IsPostBack)
            {
                this.ViewState["_PageID"] = Guid.NewGuid();
                myDBSetting = dbsetting;
                myDBSession = dbsession;

                myMaintable = new DataTable();
                myINtable = new DataTable();
                myRQtable = new DataTable();
                myCDRtable = new DataTable();

                //myMaintable = LoadMasterTable(cbMonthMaster.Text, cbYearMaster.Text);
                myMaintable = LoadMasterTable();
                myINtable = LoadINtable(cbMonth.Text, cbYear.Text);
                myRQtable = LoadRQtable(cbMonth.Text, cbYear.Text);
                myCDRtable = LoadCDRtable(cbMonth.Text, cbYear.Text);

                vgMain.DataSource = myMaintable;
                vgMain.DataBind();

                gvIN.DataSource = myINtable;
                gvIN.DataBind();

                gvRQ.DataSource = myRQtable;
                gvRQ.DataBind();

                gvCDR.DataSource = myCDRtable;
                gvCDR.DataBind();
            }
        }
        protected DataTable LoadMasterTable()
        {
            DataTable mytable = new DataTable();
            SqlConnection myconn = new SqlConnection(dbsetting.ConnectionString);
            SqlQuery = @"SELECT * FROM vTicketSummary";
            using (SqlCommand cmdheader = new SqlCommand(SqlQuery, myconn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmdheader);
                cmdheader.CommandType = CommandType.Text;
                adapter.Fill(mytable);
            }
            return mytable;
        }
        protected DataTable LoadMasterTable(string smonth, string syear)
        {
            DataTable mytable = new DataTable();
            SqlConnection myconn = new SqlConnection(dbsetting.ConnectionString);
            SqlQuery = @"SELECT * FROM vTicketSummary";
            using (SqlCommand cmdheader = new SqlCommand(SqlQuery, myconn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmdheader);
                cmdheader.CommandType = CommandType.Text;
                cmdheader.Parameters.Add("@Month", SqlDbType.NVarChar);
                cmdheader.Parameters["@Month"].Value = smonth;
                cmdheader.Parameters.Add("@Year", SqlDbType.NVarChar);
                cmdheader.Parameters["@Year"].Value = syear;
                adapter.Fill(mytable);
            }
            return mytable;
        }
        protected DataTable LoadINtable(string smonth, string syear)
        {
            DataTable mytable = new DataTable();
            SqlConnection myconn = new SqlConnection(dbsetting.ConnectionString);
            SqlQuery = @"select b.FULLNAME, count('') as TicketCount from IncidentList a 
                            inner join [dbo].[Users] b on a.CloseByUser = b.NIK 
                            where month(TicketReqDate) = @Month 
                            and year(TicketReqDate) = @Year 
                            and status <> 'REJECT' 
                            group by b.FULLNAME 
                            order by count('') desc";
            using (SqlCommand cmdheader = new SqlCommand(SqlQuery, myconn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmdheader);
                cmdheader.CommandType = CommandType.Text;
                cmdheader.Parameters.Add("@Month", SqlDbType.NVarChar);
                cmdheader.Parameters["@Month"].Value = smonth;
                cmdheader.Parameters.Add("@Year", SqlDbType.NVarChar);
                cmdheader.Parameters["@Year"].Value = syear;
                adapter.Fill(mytable);
            }
            return mytable;
        }
        protected DataTable LoadRQtable(string smonth, string syear)
        {
            DataTable mytable = new DataTable();
            SqlConnection myconn = new SqlConnection(dbsetting.ConnectionString);
            SqlQuery = @"select b.FULLNAME, count('') as TicketCount from RequestList a 
                            inner join [dbo].[Users] b on a.CloseByUser = b.NIK 
                            where month(TicketReqDate) = @Month 
                            and year(TicketReqDate) = @Year 
                            and status <> 'REJECT' 
                            group by b.FULLNAME 
                            order by count('') desc";
            using (SqlCommand cmdheader = new SqlCommand(SqlQuery, myconn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmdheader);
                cmdheader.CommandType = CommandType.Text;
                cmdheader.Parameters.Add("@Month", SqlDbType.NVarChar);
                cmdheader.Parameters["@Month"].Value = smonth;
                cmdheader.Parameters.Add("@Year", SqlDbType.NVarChar);
                cmdheader.Parameters["@Year"].Value = syear;
                adapter.Fill(mytable);
            }
            return mytable;
        }
        protected DataTable LoadCDRtable(string smonth, string syear)
        {
            DataTable mytable = new DataTable();
            SqlConnection myconn = new SqlConnection(dbsetting.ConnectionString);
            SqlQuery = @"select b.FULLNAME, count('') as TicketCount from ChangeDataList a 
                            inner join [dbo].[Users] b on a.CloseByUser = b.NIK 
                            where month(TicketReqDate) = @Month 
                            and year(TicketReqDate) = @Year 
                            and status <> 'REJECT' 
                            group by b.FULLNAME 
                            order by count('') desc";
            using (SqlCommand cmdheader = new SqlCommand(SqlQuery, myconn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmdheader);
                cmdheader.CommandType = CommandType.Text;
                cmdheader.Parameters.Add("@Month", SqlDbType.NVarChar);
                cmdheader.Parameters["@Month"].Value = smonth;
                cmdheader.Parameters.Add("@Year", SqlDbType.NVarChar);
                cmdheader.Parameters["@Year"].Value = syear;
                adapter.Fill(mytable);
            }
            return mytable;
        }
        protected void vgMain_DataBinding(object sender, EventArgs e)
        {
            (sender as ASPxVerticalGrid).DataSource = myMaintable;
        }
        protected void gvIN_DataBinding(object sender, EventArgs e)
        {
            (sender as ASPxGridView).DataSource = myINtable;
        }
        protected void gvRQ_DataBinding(object sender, EventArgs e)
        {
            (sender as ASPxGridView).DataSource = myRQtable;
        }
        protected void gvCDR_DataBinding(object sender, EventArgs e)
        {
            (sender as ASPxGridView).DataSource = myCDRtable;
        }
        protected void cplMain_Callback(object source, DevExpress.Web.CallbackEventArgs e)
        {
            cplMain.JSProperties["cpType"] = "";
            string[] callbackParam = e.Parameter.ToString().Split(';');
            cplMain.JSProperties["cpCallbackParam"] = callbackParam[0].ToUpper();
            switch (callbackParam[0].ToUpper())
            {
                case "CBMONTH_CHANGED":
                    break;
                case "CBYEAR_CHANGED":
                    break;
                case "CBMONTH_MASTER_CHANGED":
                    break;
                case "CBYEAR_MASTER_CHANGED":
                    break;
            }
        }
        protected void vgMain_CustomCallback(object sender, ASPxVerticalGridCustomCallbackEventArgs e)
        {
            isValidLogin();
            //myMaintable = LoadMasterTable(cbMonthMaster.Text, cbYearMaster.Text);
            myMaintable = LoadMasterTable();
            vgMain.DataSource = myMaintable;
            vgMain.DataBind();
        }
        protected void gvIN_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            isValidLogin();
            myINtable = LoadINtable(cbMonth.Text, cbYear.Text);
            gvIN.DataSource = myINtable;
            gvIN.DataBind();
        }
        protected void gvRQ_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            isValidLogin();
            myRQtable = LoadRQtable(cbMonth.Text, cbYear.Text);
            gvRQ.DataSource = myRQtable;
            gvRQ.DataBind();
        }
        protected void gvCDR_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            isValidLogin();
            myCDRtable = LoadCDRtable(cbMonth.Text, cbYear.Text);
            gvCDR.DataSource = myCDRtable;
            gvCDR.DataBind();

        }
        protected void cbMonth_Init(object sender, EventArgs e)
        {
            myDate = new DateTime();
            myDate = dbsetting.GetServerTime();
            cbMonth.Text = myDate.Month.ToString();
        }
        protected void cbYear_Init(object sender, EventArgs e)
        {
            myDate = new DateTime();
            myDate = dbsetting.GetServerTime();
            cbYear.Text = myDate.Year.ToString();
        }
        protected void cbMonthMaster_Init(object sender, EventArgs e)
        {
            myDate = new DateTime();
            myDate = dbsetting.GetServerTime();
            cbMonthMaster.Text = myDate.Month.ToString();
        }
        protected void cbYearMaster_Init(object sender, EventArgs e)
        {
            myDate = new DateTime();
            myDate = dbsetting.GetServerTime();
            cbYearMaster.Text = myDate.Year.ToString();
        }
    }
}