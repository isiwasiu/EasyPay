using NibbssNPSPaymentStack.Business.Models.Pain009;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibbssNPSPaymentStack.Business.Models.Pain009
{
    public class MndtInitnReq
    {
        public Pain009GrpHdr? GrpHdr { get; set; }
        public Mndt? Mndt { get; set; }
        public SplmtryData? SplmtryData { get; set; }
    }
}



