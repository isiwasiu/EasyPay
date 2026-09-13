using NibbssNPSPaymentStack.Business.Models.Pacs008;
using NibbssNPSPaymentStack.Business.Models.Pain013;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain001
{
    public class CustomerCreditTransferInitiation
    {

        [XmlElement("GrpHdr", Namespace = "")]
        public Pain001GrpHdr? GrpHdr { get; set; }

        [XmlElement("PmtInf", Namespace = "")]
        public Pain001PaymentInformation? PaymentInformation { get; set; }

        [XmlElement("SplmtryData", Namespace = "")]
        public Pain001SupplementaryData? SupplementaryData { get; set; }

    }
}
