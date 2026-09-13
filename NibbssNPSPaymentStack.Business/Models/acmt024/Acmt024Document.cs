using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.acmt024
{
    [XmlRoot("Document", Namespace = "urn:iso:std:iso:20022:tech:xsd:acmt.024.001.04")]
    public class Acmt024Document
    {
        [XmlElement("IdVrfctnRpt", Namespace ="")]
        public IdVrfctnRpt? IdVrfctnRpt { get; set; }
    }
}
