using NibbssNPSPaymentStack.Business.Models.acmt023;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain014
{
    public class Pain014GroupHeader
    {
        [XmlElement("MsgId")]
        public string? MessageId { get; set; }

        [XmlElement("CreDtTm")]
        public DateTime CreationDateTime { get; set; }

        [XmlElement("InitgPty")]
        public Party? InitiatingParty { get; set; }

        [XmlElement("Cdtr")]
        public Party? Creditor { get; set; }

        [XmlElement("CdtrAcct")]
        public Account? CreditorAccount { get; set; }

        [XmlElement("Dbtr")]
        public Party? Debtor { get; set; }

        [XmlElement("DbtrAcct")]
        public Account? DebtorAccount { get; set; }

        [XmlElement("FwdgAgt")]
        public FinancialAgent? ForwardingAgent { get; set; }

        [XmlElement("DbtrAgt")]
        public FinancialAgent? DebtorAgent { get; set; }

        [XmlElement("CdtrAgt")]
        public FinancialAgent? CreditorAgent { get; set; }


    }
}
