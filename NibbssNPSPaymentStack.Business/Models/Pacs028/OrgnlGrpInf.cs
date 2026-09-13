using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pacs028
{
    public class OrgnlGrpInf
    {
        [XmlElement(ElementName = "OrgnlMsgId")]
        public string? OrgnlMsgId { get; set; }

        [XmlElement(ElementName = "OrgnlMsgNmId")]
        public string? OrgnlMsgNmId { get; set; }

        [XmlElement(ElementName = "OrgnlCreDtTm")]
        public DateTime OrgnlCreDtTm { get; set; }
    }
}
