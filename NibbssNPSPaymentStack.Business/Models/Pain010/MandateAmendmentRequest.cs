using NibbssNPSPaymentStack.Business.Models.Pacs008;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain010
{
    public class MandateAmendmentRequest
    {
        [XmlElement(ElementName = "GrpHdr")]
        public Pain010GrpHdr? GrpHdr { get; set; }

        [XmlElement(ElementName = "UndrlygAmdmntDtls")]
        public UnderlyingAmendmentDetails? UndrlygAmdmntDtls { get; set; }
    }
}
