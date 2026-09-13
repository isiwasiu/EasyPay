using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Camt060
{
    [XmlRoot("Document", Namespace = "urn:iso:std:iso:20022:tech:xsd:camt.060.001.07")]
    public class camt060Document
    {
        [XmlElement("AcctRptgReq",Namespace ="")]
        public AccountReportingRequest? AccountReportingRequest { get; set; }

    }
}
