using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Camt053
{
    public class CodeOrProprietary
    {
        [XmlElement("Cd")]
        public string? Cd { get; set; }

        [XmlElement("Prtry")]
        public string? Prtry { get; set; }
    }
}
