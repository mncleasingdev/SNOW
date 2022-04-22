using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using TableDependency;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base;
using System.Configuration;
using TableDependency.SqlClient.Base.EventArgs;
using TableDependency.SqlClient.Base.Enums;
using System.Data.SqlClient;
using System.Web.Caching;

namespace DXMNCGUI_SNOW.Controllers
{
    public sealed class SqlWatcher
    {
        public SqlWatcher(string sQuery, string connectionString, int numberOfMinutes)
        {
            DateTime.Now.ToLongTimeString();
            SqlDependency.Start(connectionString);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sQuery, connection))
                {
                    SqlCacheDependency dependency = new SqlCacheDependency(command);
                    // Refresh the cache after the number of minutes
                    // listed below if a change does not occur.
                    // This value could be stored in a configuration file.
                    DateTime expires = DateTime.Now.AddMinutes(numberOfMinutes);

                    //Response.Cache.SetExpires(expires);
                    //Response.Cache.SetCacheability(HttpCacheability.Public);
                    //Response.Cache.SetValidUntilExpires(true);

                    //Response.AddCacheDependency(dependency);

                    connection.Open();

                    //GridView1.DataSource = command.ExecuteReader();
                    //GridView1.DataBind();
                }
            }
        }
    }
}