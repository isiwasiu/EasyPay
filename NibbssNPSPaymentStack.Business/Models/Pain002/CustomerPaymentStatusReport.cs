using NibbssNPSPaymentStack.Business.Models.Pacs008;
using NibbssNPSPaymentStack.Business.Models.Pain014;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain002
{
    public class CustomerPaymentStatusReport
    {

        [XmlElement("GrpHdr")]
        public Pain002GrpHdr? GrpHdr { get; set; }

        [XmlElement("OrgnlGrpInfAndSts")]
        public Pain002OriginalGroupInformationAndStatus? OrgnlGrpInfAndSts { get; set; }

        [XmlElement("OrgnlPmtInfAndSts")]
        public Pain002OriginalPaymentInformationAndStatus? OrgnlPmtInfAndSts { get; set; }

    }
}
