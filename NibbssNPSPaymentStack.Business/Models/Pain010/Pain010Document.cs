using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain010
{
    [XmlRoot(ElementName = "Document", Namespace = "urn:iso:std:iso:20022:tech:xsd:pain.010.001.08")]
    public class Pain010Document
    {
        [XmlElement(ElementName = "MndtAmdmntReq",Namespace ="")]
        public MandateAmendmentRequest? MndtAmdmntReq { get; set; }
    }
}
