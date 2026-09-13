using System;

using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.acmt023
{
    public class FinancialInstitutionId
    {
        [XmlElement("BICFI")]
        public string? BICFI { get; set; }

        [XmlElement("ClrSysMmbId")]
        public ClearingSystemMemberId? ClearingSystemMemberId { get; set; }
    }
}
