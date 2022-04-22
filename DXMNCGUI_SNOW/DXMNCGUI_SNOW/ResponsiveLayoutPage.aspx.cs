using DXMNCGUI_SNOW.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DXMNCGUI_SNOW
{
    public partial class ResponsiveLayoutPage : BasePage
    {
        string SqlQuery = string.Empty;

        protected SqlDBSetting myDBSetting
        {
            get { isValidLogin(true); return (SqlDBSetting)HttpContext.Current.Session["HomeSqlDBSetting" + this.ViewState["_PageID"]]; }
            set { HttpContext.Current.Session["HomeSqlDBSetting" + this.ViewState["_PageID"]] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                
            }
            MyWatcher();
        }
        void MyWatcher()
        {
            
            // Assume connection is an open SqlConnection.

            // Create a new SqlCommand object.
            SqlConnection conn = new SqlConnection(myDBSetting.ConnectionString);
            SqlDependency.Start(ConfigurationManager.ConnectionStrings["connectionString"].ToString(), "SqlDepTable");
            using (SqlCommand command = new SqlCommand("SELECT ShipperID, CompanyName, Phone FROM dbo.Shippers", conn))
            {

                // Create a dependency and associate it with the SqlCommand.
                SqlDependency dependency = new SqlDependency(command);
                // Maintain the refence in a class member.

                // Subscribe to the SqlDependency event.
                dependency.OnChange += new OnChangeEventHandler(OnDependencyChange);

                // Execute the command.
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Process the DataReader.
                }
            }
        }
        // Handler method
        void OnDependencyChange(object sender, SqlNotificationEventArgs e)
        {
            // Handle the event (for example, invalidate this cache entry).
        }

        void Termination()
        {
            // Release the dependency.
            SqlDependency.Stop(ConfigurationManager.ConnectionStrings["connectionString"].ToString(), "SqlDepTable");
        }
        }
    }