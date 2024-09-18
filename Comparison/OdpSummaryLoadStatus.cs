using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparison
{
    public enum OdpSummaryLoadStatus
    {
        [Description("Successful")]
        Successful = 1,

        [Description("Failure")]
        Failure,

        [Description("Pending")]
        Pending,

        [Description("Loading")]
        Loading
    }
}
