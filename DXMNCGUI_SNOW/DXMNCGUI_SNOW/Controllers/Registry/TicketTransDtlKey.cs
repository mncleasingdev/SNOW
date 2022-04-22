using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BCE.Data;
namespace DXMNCGUI_SNOW.Controllers.Registry
{
    public class TicketTransDtlKey : BaseRegistryID
    {
        protected override void Init()
        {
            this.myID = 13399;
            this.myDefaultValue = (object)1;
        }
    }
}