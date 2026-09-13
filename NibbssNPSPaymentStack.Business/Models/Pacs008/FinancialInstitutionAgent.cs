using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pacs008
{

    public class FinancialInstitutionAgent
    {
        [XmlElement("FinInstnId")]
        public FinancialInstitutionIdentification? FinInstnId { get; set; }
    }
}
