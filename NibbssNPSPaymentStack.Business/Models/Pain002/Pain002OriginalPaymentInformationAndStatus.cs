using NibbssNPSPaymentStack.Business.Models.Pain014;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain002
{
    public class Pain002OriginalPaymentInformationAndStatus
    {

        [XmlElement("OrgnlPmtInfId")]
        public string? OrgnlPmtInfId { get; set; }

        [XmlElement("TxInfAndSts")]
        public Pain002TransactionInformationAndStatus? TxInfAndSts { get; set; }

    }
}
