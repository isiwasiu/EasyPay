using NibbssNPSPaymentStack.Business.Models.Pacs008;
using NibbssNPSPaymentStack.Business.Models.Pain009;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibbssNPSPaymentStack.Business.Models.pain011
{
    public class MandateCancellationRequest
    {
        public Pain009GrpHdr? GrpHdr { get; set; }

        public UnderlyingCancellationDetails? UndrlygCxlDtls { get; set; }
    }
}
