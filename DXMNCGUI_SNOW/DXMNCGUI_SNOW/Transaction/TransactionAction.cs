using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXMNCGUI_SNOW.Transaction
{
    public enum TransactionAction
    {
        New,
        View,
        Edit,
        Drag,
        Delete,
        Incomplete,
        Complete,
        Cancel,
        Approve,
        In_Process,
        Pre_Approve,
        Rejected,
        Requires_ReApproval,
        Open
    }
}