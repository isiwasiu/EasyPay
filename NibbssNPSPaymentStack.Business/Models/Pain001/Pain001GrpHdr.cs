using NibbssNPSPaymentStack.Business.Models.acmt023;
using NibbssNPSPaymentStack.Business.Models.Pain010;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain001
{
    public class Pain001GrpHdr
    {

        [XmlElement("MsgId", Namespace = "")]
        public string? MessageId { get; set; }

        [XmlElement("CreDtTm", Namespace = "")]
        public DateTime CreateAt { get; set; }

        [XmlElement("NbOfTxs", Namespace = "")]
        public int NumberOfTransactions { get; set; }

        [XmlElement("CtrlSum", Namespace = "")]
        public decimal TotalSumAmount { get; set; }

        [XmlElement("InitgPty", Namespace = "")]
        public Pain00InitgPty? InitiatingParty { get; set; }

        [XmlElement("FwdgAgt", Namespace = "")]
        public Pain001Agent? ForwardingAgent { get; set; }

    }
}
