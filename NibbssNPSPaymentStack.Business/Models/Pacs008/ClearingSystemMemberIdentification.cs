using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pacs008
{
    public class ClearingSystemMemberIdentification
    {
        [XmlElement("MmbId")]
        public string? MmbId { get; set; }
    }
}
