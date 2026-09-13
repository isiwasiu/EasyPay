using NibbssNPSPaymentStack.Business.Models.acmt023;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pacs002
{
    public class Pacs002TxInfAndSts
    {
        public string? StsId {  get; set; }
        public string? OrgnlInstrId { get; set; }
        public string? OrgnlEndToEndId { get; set; }
        public string? OrgnlTxId { get; set; }

        [XmlElement(ElementName = "InstgAgt")]
        public Agent? InstgAgt3 { get; set; }

        [XmlElement(ElementName = "InstdAgt")]
        public Agent? InstdAgt4 { get; set; }

        [XmlElement(ElementName = "OrgnlTxRef")]
        public OrgnlTxRef? OrgnlTxRef { get; set; }
    }
}
