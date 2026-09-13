using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Camt053
{
    public class ValueDate
    {
        [XmlElement("Dt")]
        public string?  Dt { get; set; }
    }
}
