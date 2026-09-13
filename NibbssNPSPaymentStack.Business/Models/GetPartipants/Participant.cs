using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.GetPartipants
{
    public class Participant
    {
        [XmlAttribute("institutionCode")]
        public string? InstitutionCode { get; set; }

        [XmlElement("bicfic")]
        public string? Bicfic { get; set; }

        [XmlElement("name")]
        public string? Name { get; set; }

        [XmlElement("countryCode")]
        public string? CountryCode { get; set; }

        [XmlElement("status")]
        public string? Status { get; set; }

        [XmlElement("categoryCode")]
        public int CategoryCode { get; set; }

        [XmlElement("currencies")]
        public Currencies? Currencies { get; set; }

        [XmlElement("operationsAllowed")]
        public OperationsAllowed? OperationsAllowed { get; set; }
    }
}
