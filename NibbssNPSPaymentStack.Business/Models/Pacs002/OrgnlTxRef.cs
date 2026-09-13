using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pacs002
{
    public class OrgnlTxRef
    {
        [XmlElement(ElementName = "IntrBkSttlmDt")]
        public string? IntrBkSttlmDt { get; set; }
    }
}
