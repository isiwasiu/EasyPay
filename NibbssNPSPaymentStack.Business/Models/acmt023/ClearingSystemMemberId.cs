
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.acmt023
{
    public class ClearingSystemMemberId
    {
        [XmlElement("MmbId")]
        public string? MmbId { get; set; }
    }
}
