using NibbssNPSPaymentStack.Business.Models.Pacs002;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain012
{
    [XmlRoot(ElementName = "Document", Namespace = "urn:iso:std:iso:20022:tech:xsd:pain.012.001.08")]
    public class pain012Document
    {
        [XmlElement(ElementName = "MndtAccptncRpt", Namespace ="")]
        public MandateAcceptanceReport? MndtAccptncRpt { get; set; }
    }
}
