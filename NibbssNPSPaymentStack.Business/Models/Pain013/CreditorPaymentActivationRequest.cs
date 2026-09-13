using NibbssNPSPaymentStack.Business.Models.Pacs008;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain013
{
    public class CreditorPaymentActivationRequest
    {
        [XmlElement("GrpHdr")]
        public Pain013GrpHdr? GrpHdr { get; set; }

        [XmlElement("PmtInf")]
        public PaymentInformation? PaymentInformation { get; set; }

        [XmlElement("SplmtryData")]
        public Pain013SupplementaryData? SupplementaryData { get; set; }

    }
}
