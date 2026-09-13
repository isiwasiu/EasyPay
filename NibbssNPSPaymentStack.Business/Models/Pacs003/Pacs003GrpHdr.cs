using NibbssNPSPaymentStack.Business.Models.acmt023;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pacs003
{
    public class Pacs003GrpHdr
    {
        [XmlElement(ElementName = "MsgId")]
        public string? MsgId { get; set; }

        [XmlElement(ElementName = "CreDtTm")]
        public DateTime CreDtTm { get; set; }

        [XmlElement(ElementName = "NbOfTxs")]
        public int NbOfTxs { get; set; }

        [XmlElement(ElementName = "CtrlSum")]
        public decimal CtrlSum { get; set; }

        [XmlElement(ElementName = "InstgAgt")]
        public Agent? InstgAgt { get; set; }

        [XmlElement(ElementName = "InstdAgt")]
        public Agent? InstdAgt2 { get; set; }
    }
}
