using NibbssNPSPaymentStack.Business.Models.acmt023;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pacs002
{
    public class GrpHdr
    {
        [XmlElement("MsgId")]
        public string? MsgId { get; set; }

        [XmlElement("CreDtTm")]
        public DateTime CreDtTm { get; set; }

        [XmlElement("InstgAgt")]
        public Agent? InstgAgt { get; set; }

        [XmlElement("InstdAgt")]
        public Agent? InstdAgt2 { get; set; }
    }
}
