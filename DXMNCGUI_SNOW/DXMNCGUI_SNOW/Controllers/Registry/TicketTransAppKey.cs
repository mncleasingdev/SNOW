using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BCE.Data;
namespace DXMNCGUI_SNOW.Controllers.Registry
{
    public class TicketTransAppKey : BaseRegistryID
    {
        protected override void Init()
        {
            this.myID = 13377;
            this.myDefaultValue = (object)1;
        }
    }
}