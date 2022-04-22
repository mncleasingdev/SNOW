using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using DXMNCGUI_SNOW.Controllers;
using System.Security;
using System.Web.Security;
using System.Configuration;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web.SessionState;
using Owin;
using System.Security.Authentication;
using System.Xml.Linq;
using System.Web.Configuration;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;


namespace DXMNCGUI_SNOW
{
    public partial class RootMaster : System.Web.UI.MasterPage
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
        protected string UserID
        {
            get { return (string)HttpContext.Current.Session["UserID"]; }
            set { HttpContext.Current.Session["UserID"] = value; }
        }
        protected string UserFullName
        {
            get { return (string)HttpContext.Current.Session["UserFullName"]; }
            set { HttpContext.Current.Session["UserFullName"] = value; }
        }
        protected SqlDBSetting dbsetting
        {
            get { return (SqlDBSetting)HttpContext.Current.Session["SqlDBSetting"]; }
            set { HttpContext.Current.Session["SqlDBSetting"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ASPxLabel2.Text = DateTime.Now.Year + Server.HtmlDecode(" &copy; MNC Leasing all rights reserved");
            try
            {
                var lblUserName = this.HeadLoginView.FindControl("lblUserName") as ASPxLabel;
                if (lblUserName != null)
                {
                    lblUserName.Text = "Welcome, " + myDBSetting.ExecuteScalar("SELECT FULLNAME FROM USERS WHERE NIK=?", HttpContext.Current.Session["UserID"].ToString());
                }
            }
            catch
            {
                HttpContext.Current.Session.Abandon();
                FormsAuthentication.SignOut();
                DevExpress.Web.ASPxWebControl.RedirectOnCallback("~/Account/Login.aspx");
            }
        }
        protected void HeadLoginStatus_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            HttpContext.Current.Session.Abandon();
            FormsAuthentication.SignOut();
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

        protected void ASPxCallback_Callback(object source, CallbackEventArgs e)
        {
            if (e.Parameter == "LogOut")
            {
                myDBSession.Logout();
                HttpContext.Current.Session.Abandon();
                Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                DevExpress.Web.ASPxWebControl.RedirectOnCallback("~/Account/Login.aspx");
            }
        }
    }
}