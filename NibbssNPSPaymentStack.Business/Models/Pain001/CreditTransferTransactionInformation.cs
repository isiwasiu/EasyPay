using NibbssNPSPaymentStack.Business.Models.acmt023;
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
    public class CreditTransferTransactionInformation
    {

        [XmlElement("PmtId")]
        public PmtId? PaymentIdentification { get; set; }

        [XmlElement("Amt")]
        public Pain013Amount? Amount { get; set; }

        [XmlElement("CdtrAgt")]
        public Agent? CreditorAgent { get; set; }

        [XmlElement("Cdtr")]
        public Party? Creditor { get; set; }

        [XmlElement("CdtrAcct")]
        public Account? CreditorAccount { get; set; }

        [XmlElement("RmtInf")]
        public RemittanceInformation? RemittanceInformation { get; set; }

    }
}
