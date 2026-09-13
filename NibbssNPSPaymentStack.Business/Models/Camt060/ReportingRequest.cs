using NibbssNPSPaymentStack.Business.Models.acmt023;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Camt060
{
    public class ReportingRequest
    {

        [XmlElement("Id")]
        public string? Id { get; set; }

        [XmlElement("ReqdMsgNmId")]
        public string? RequestedMessageNameId { get; set; }

        [XmlElement("Acct")]
        public Camt060Account? Account { get; set; }

        [XmlElement("AcctOwnr")]
        public AccountOwner? AccountOwner { get; set; }

        [XmlElement("AcctSvcr")]
        public AccountServicer? AccountServicer { get; set; }

        [XmlElement("RptgPrd")]
        public ReportingPeriod? ReportingPeriod { get; set; }

    }
}
