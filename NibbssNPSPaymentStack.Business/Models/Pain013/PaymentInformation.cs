using NibbssNPSPaymentStack.Business.Models.acmt023;
using NibbssNPSPaymentStack.Business.Models.Pacs008;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain013
{
    public class PaymentInformation
    {
        [XmlElement("PmtInfId")]
        public string? PaymentInformationId { get; set; }

        [XmlElement("PmtMtd")]
        public string? PaymentMethod { get; set; }

        [XmlElement("ReqdExctnDt")]
        public RequestedExecutionDate? RequestedExecutionDate { get; set; }

        [XmlElement("Dbtr")]
        public Party? Debtor { get; set; }

        [XmlElement("DbtrAcct")]
        public Pain013Account? DebtorAccount { get; set; }

        [XmlElement("DbtrAgt")]
        public Agent? DebtorAgent { get; set; }

        [XmlElement("CdtTrfTx")]
        public Pain013CreditTransferTransaction? CreditTransferTransaction { get; set; }


    }
}
