using Microsoft.Owin;
using Owin;
using System.Configuration;
using System.Data.SqlClient;

[assembly: OwinStartup(typeof(DXMNCGUI_SNOW.Startup))]

// Files related to ASP.NET Identity duplicate the Microsoft ASP.NET Identity file structure and contain initial Microsoft comments.

namespace DXMNCGUI_SNOW
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}