using NibbssNPSPaymentStack.Business.Models.Pain013;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Camt060
{
    public class AccountReportingRequest
    {
        [XmlElement("GrpHdr")]
        public Camt060GrpHdr? GrpHdr { get; set; }

        [XmlElement("RptgReq")]
        public ReportingRequest? ReportingRequest { get; set; }

        [XmlElement("SplmtryData")]
        public Camt060SupplementaryData? SupplementaryData { get; set; }

    }
}
