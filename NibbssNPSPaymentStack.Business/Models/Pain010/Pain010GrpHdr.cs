using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain010
{
    public class Pain010GrpHdr
    {
        [XmlElement(ElementName = "MsgId")]
        public string? MsgId { get; set; }

        [XmlElement(ElementName = "CreDtTm")]
        public DateTime CreDtTm { get; set; }

        [XmlElement(ElementName = "InitgPty")]
        public InitgPty? InitgPty { get; set; }

    }
}
