using NibbssNPSPaymentStack.Business.Models.Pain010;
using NibbssNPSPaymentStack.Business.Models.Pain012;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibbssNPSPaymentStack.Business.Models.pain011
{
    public class UnderlyingCancellationDetails
    {
        public OriginalMessageInfo? OrgnlMsgInf { get; set; }

        public CancellationReason? CxlRsn { get; set; }

        public OriginalMandateWrapper? OrgnlMndt { get; set; }
    }
}
