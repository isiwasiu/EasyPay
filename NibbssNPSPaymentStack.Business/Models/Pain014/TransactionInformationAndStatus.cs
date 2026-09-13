using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain014
{
    public class TransactionInformationAndStatus
    {

        [XmlElement("OrgnlEndToEndId")]
        public string? OriginalEndToEndId { get; set; }

        [XmlElement("TxSts")]
        public string? TransactionStatus { get; set; }

    }
}
