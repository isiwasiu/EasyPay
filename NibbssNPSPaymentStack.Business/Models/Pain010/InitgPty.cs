
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain010
{
    public class InitgPty
    {
        [XmlElement(ElementName = "Nm")]
        public string? Nm { get; set; }
    }
}
