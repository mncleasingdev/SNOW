using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BCE.Data;
namespace DXMNCGUI_SNOW.Controllers.Registry
{
    public class TicketTransImgKey : BaseRegistryID
    {
        protected override void Init()
        {
            this.myID = 13366;
            this.myDefaultValue = (object)1;
        }
    }
}