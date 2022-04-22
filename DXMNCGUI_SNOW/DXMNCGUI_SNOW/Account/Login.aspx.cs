using DXMNCGUI_SNOW;
using DXMNCGUI_SNOW.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using System.Web.Security;
using System.Reflection;
using System.Configuration;
using System.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
namespace DXMNCGUI_SNOW.Account
{
    public partial class Login : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["SessionExpired"] != null)
                {
                    string strPage = "";
                    strPage = Request.QueryString["SessionExpired"].ToString();
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Sorry , " + strPage + "...');", true);
                }
                Session.Abandon();
                this.mInitialize();
                object value = Cache["SCH_Company"];
            }
        }
        private void mInitialize()
        {
            String strClientScript = "if(event.keyCode==13){ " + Page.ClientScript.GetPostBackEventReference(this, "Login", false) + "; }";
            txtUserName.Attributes.Add("onkeydown", strClientScript);
            txtPassword.Attributes.Add("onkeydown", strClientScript);
            lblMessage.Text = "";
            txtUserName.Focus();
            lblVersion.Text = ""; //myVersion.strVersionID;
            this.mExtractQueryString();
            Connection();
        }
        private void Connection()
        {
            this.dbsetting = new SqlDBSetting(BCE.Data.DBServerType.SQL2000, GetSqlConnectionString(), 60);
        }
        private Boolean fIsEntryValid()
        {
            if ("" == txtUserName.Text)
            {
                lblMessage.Text = "User name must be filled!";
                txtUserName.Focus();
                return false;
            }
            else if ("" == txtPassword.Text)
            {
                lblMessage.Text = "Password must be filled!";
                txtPassword.Focus();
                return false;
            }
            return true;
        }
        private void mExtractQueryString()
        {
            String strMessageID = Server.UrlDecode(Request.QueryString["MsgID"]);

            switch (strMessageID)
            {
                case "1":
                    lblMessage.Text = "Sorry, your session expired.";
                    break;

                default:
                    break;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            Connection();
            if (!fIsEntryValid()) { return; }
            this.dbsession = SqlDBSession.Create(dbsetting);
            this.dbsession.UseEncryptedPassword = true;

            if (this.dbsession.Login(txtUserName.Text, txtPassword.Text))
            {
                this.UserID = this.dbsession.LoginUserID.ToUpper();
                this.dbsession.LoginNoUrut = txtUserName.Text.ToUpper();
                this.SessionID = Guid.NewGuid();
                accessright = AccesRight.Create(dbsetting, this.UserID);
                object obj = dbsetting.ExecuteScalar("select NIK from Users where NIK=?", (object)this.UserID);
                if (obj != null && obj != DBNull.Value)
                {
                    this.UserName = obj.ToString();
                }

                if (IsValid)
                {
                    if (this.Request.QueryString["SourceType"] != null && this.Request.QueryString["SourceKey"] != null)
                    {
                        string sourceType = this.Request.QueryString["SourceType"].ToString();
                        string sourceKey = this.Request.QueryString["SourceKey"].ToString();
                        return;
                    }
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                }
            }
            else
            {
                lblMessage.Text = "User name or password invalid!";
                txtPassword.Focus();
                return;
            }
        }
        private void userexists(string strUserName, string strPassword)
        {
            try
            {
                MembershipUser userexists = Membership.GetUser(strUserName.ToUpper(), false);
                if (userexists == null)
                {
                    MembershipUser newuser = Membership.CreateUser(strUserName, strPassword, "www." + strUserName + "@gmail.com");
                }
                else
                {
                    userexists.ChangePassword(userexists.ResetPassword(), strPassword);
                }
            }
            catch { }
        }
        protected void lbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void lbCompany_CustomJSProperties(object sender, DevExpress.Web.CustomJSPropertiesEventArgs e)
        {

        }

        protected void lbCompany_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            string[] callbackParam = e.Parameter.ToString().Split(';');
        }

        protected void cplMain_Callback(object source, DevExpress.Web.CallbackEventArgs e)
        {
            string[] callbackParam = e.Parameter.ToString().Split(';');
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/WebForm1.aspx");
        }
    }
}