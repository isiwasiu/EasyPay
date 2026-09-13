using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain010
{
    public class OriginalMessageInfo
    {
        [XmlElement(ElementName = "MsgId",Namespace ="")]
        public string? MsgId { get; set; }

        [XmlElement(ElementName = "MsgNmId", Namespace = "")]
        public string? MsgNmId { get; set; }

        [XmlElement(ElementName = "CreDtTm", Namespace = "")]
        public DateTime CreDtTmm { get; set; }
    }
}
