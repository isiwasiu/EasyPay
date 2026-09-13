using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain010
{
    public class UnderlyingAmendmentDetails
    {
        [XmlElement(ElementName = "OrgnlMsgInf")]
        public OriginalMessageInfo? OrgnlMsgInf { get; set; }

        [XmlElement(ElementName = "AmdmntRsn")]
        public AmendmentReason? AmdmntRsn { get; set; }

        [XmlElement(ElementName = "Mndt")]
        public Mandate? Mndt { get; set; }

        [XmlElement(ElementName = "OrgnlMndt")]
        public OriginalMandate? OrgnlMndt { get; set; }
    }
}
