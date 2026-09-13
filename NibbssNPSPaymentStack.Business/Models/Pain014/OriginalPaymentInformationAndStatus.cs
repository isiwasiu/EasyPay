using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain014
{
    public class OriginalPaymentInformationAndStatus
    {

        [XmlElement("OrgnlPmtInfId")]
        public string? OriginalPaymentInformationId { get; set; }

        [XmlElement("TxInfAndSts")]
        public TransactionInformationAndStatus? TransactionInformationAndStatus { get; set; }

    }
}
