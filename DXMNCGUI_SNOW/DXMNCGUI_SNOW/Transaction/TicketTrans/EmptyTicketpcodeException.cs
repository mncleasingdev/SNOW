using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXMNCGUI_SNOW.Transaction.TicketTrans
{
    public class EmptyTicketpcodeException : Exception
    {
        public EmptyTicketpcodeException()
            : base("Empty DocNo  is not allowed.")
        {
        }
    }
}