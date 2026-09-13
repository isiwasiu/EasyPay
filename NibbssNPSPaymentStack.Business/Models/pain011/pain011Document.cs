using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.pain011
{
    [XmlRoot(ElementName = "Document", Namespace = "urn:iso:std:iso:20022:tech:xsd:pain.011.001.08")]
    public class pain011Document
    {
        [XmlElement(ElementName = "MndtCxlReq",Namespace ="")]
        public MandateCancellationRequest? MndtCxlReq { get; set; }
    }
}
