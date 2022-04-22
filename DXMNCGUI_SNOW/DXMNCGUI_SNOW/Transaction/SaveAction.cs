using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXMNCGUI_SNOW.Transaction
{
    public enum SaveAction
    {
        Save,
        Approve,
        Reject,
        Submit,
        UnSubmit,
        UnCancel,
        Cancel,
        In_Process,
        Grab,
        Close,
        OnHold,
        OverWrite,
    }
}