using NibbssNPSPaymentStack.Business.Models.acmt023;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Camt053
{
    public class Servicer
    {
        [XmlElement("FinInstnId")]
        public FinancialInstitutionId? FinInstnId { get; set; }
    }
}
