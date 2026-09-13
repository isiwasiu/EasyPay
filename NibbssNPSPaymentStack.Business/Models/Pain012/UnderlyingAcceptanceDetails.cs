using NibbssNPSPaymentStack.Business.Models.Pain010;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain012
{
    public class UnderlyingAcceptanceDetails
    {
        [XmlElement(ElementName = "OrgnlMsgInf", Namespace = "")]
        public OriginalMessageInfo? OrgnlMsgInf { get; set; }

        [XmlElement(ElementName = "AccptncRslt", Namespace = "")]
        public AcceptanceResult? AccptncRslt { get; set; }

        [XmlElement(ElementName = "OrgnlMndt", Namespace = "")]
        public OriginalMandateWrapper? OrgnlMndt { get; set; }
    }
}
