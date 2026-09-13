using NibbssNPSPaymentStack.Business.Models.acmt023;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pacs003
{
    [XmlRoot(ElementName = "DrctDbtTx",Namespace ="")]
    public class DirectDebitTransactionInfo
    {
        public PaymentId? PmtId { get; set; }

        [XmlElement("IntrBkSttlmAmt",Namespace ="")]
        public IntrBkSttlmAmt? IntrBkSttlmAmt { get; set; }
        public DateTime IntrBkSttlmDt { get; set; }

        [XmlElement("InstdAmt", Namespace ="")]
        public InstdAmt? InstdAmt { get; set; }

        [XmlElement(ElementName = "DrctDbtTx", Namespace ="")]
        public DrctDbtTx? DrctDbtTx { get; set; }
        public Party? Cdtr { get; set; }
        public Account? CdtrAcct { get; set; }
        public Agent? CdtrAgt { get; set; }
        public Agent? InstgAgt { get; set; }
        public Agent? InstdAgt2 { get; set; }
        public Party? Dbtr { get; set; }
        public Account? DbtrAcct { get; set; }
        public Agent? DbtrAgt { get; set; }
        public RemittanceInfo? RmtInf { get; set; }
    }
}
