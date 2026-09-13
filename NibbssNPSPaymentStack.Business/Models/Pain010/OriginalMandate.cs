
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain010
{
    public class OriginalMandate
    {
        [XmlElement(ElementName = "OrgnlMndtId")]
        public string? OrgnlMndtId { get; set; }
    }
}
