using NibbssNPSPaymentStack.Business.Models.Pacs008;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain014
{
    public class CreditorPaymentActivationRequestStatusReport
    {

        [XmlElement("GrpHdr")]
        public Pain014GroupHeader? GrpHdr { get; set; }

        [XmlElement("OrgnlGrpInfAndSts")]
        public OriginalGroupInformationAndStatus? OriginalGroupInformationAndStatus { get; set; }

        [XmlElement("OrgnlPmtInfAndSts")]
        public OriginalPaymentInformationAndStatus? OriginalPaymentInformationAndStatus { get; set; }

    }
}
