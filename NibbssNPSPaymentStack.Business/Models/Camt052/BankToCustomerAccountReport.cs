using NibbssNPSPaymentStack.Business.Models.acmt024;
using NibbssNPSPaymentStack.Business.Models.Camt053;
using NibbssNPSPaymentStack.Business.Models.Pacs008;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Camt052
{
    public class BankToCustomerAccountReport
    {
        [XmlElement("GrpHdr")]
        public Camt053GrpHdr? GrpHdr { get; set; }

        [XmlElement("Rpt")]
        public Camt052Report? Rpt { get; set; }
    }
}
