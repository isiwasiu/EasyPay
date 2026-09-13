using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pacs008
{
    public class PaymentIdentification
    {
        [XmlElement("InstrId")]
        public string? InstrId { get; set; }

        [XmlElement("EndToEndId")]
        public string? EndToEndId { get; set; }

        [XmlElement("TxId")]
        public string? TxId { get; set; }
    }
}
