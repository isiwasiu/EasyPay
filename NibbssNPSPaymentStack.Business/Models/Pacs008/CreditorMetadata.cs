
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pacs008
{
    [XmlRoot("CreditorMetadata")]
    public class CreditorMetadata
    {
        [XmlElement("AnyOtherData")]
        public string? AnyOtherData { get; set; }
    }
}
