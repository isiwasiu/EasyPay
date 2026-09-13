using NibbssNPSPaymentStack.Business.Models.acmt023;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain014
{
    public class FinancialAgent
    {
        [XmlElement("FinInstnId")]
        public FinancialInstitutionId? FinancialInstitution { get; set; }

    }
}
