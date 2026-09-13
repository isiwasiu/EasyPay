using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain014
{
    [XmlRoot("Document", Namespace = "urn:iso:std:iso:20022:tech:xsd:pain.014.001.11")]
    public class Pain014Document
    {
        [XmlElement("CdtrPmtActvtnReqStsRpt", Namespace = "")]
        public CreditorPaymentActivationRequestStatusReport? StatusReport { get; set; }
    }
}


//namespace NibbssNPSPaymentStack.Business.Models.Pain014
//{
//    [XmlRoot("Document", Namespace = "urn:iso:std:iso:20022:tech:xsd:pain.014.001.11")]
//    public class Pain014Document
//    {
//        [XmlElement("CdtrPmtActvtnReqStsRpt", Namespace ="")]
//        public CreditorPaymentActivationRequestStatusReport? StatusReport { get; set; }
//    }
//}
