using NibbssNPSPaymentStack.Business.Models.acmt024;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.acmt023
{
    
    public class Agent
    {
        [XmlElement("FinInstnId", Namespace = "")]
        public FinancialInstitutionId? FinancialInstitution { get; set; }
    }
}
