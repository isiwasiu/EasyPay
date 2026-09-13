using NibbssNPSPaymentStack.Business.Models.Pacs008;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain001
{
    public class Pain001CustomData
    {
        [XmlElement("CreditorInfo")]
        public CreditorInfo? CreditorInfo { get; set; }

        [XmlElement("TransactionInfo")]
        public Pain001TransactionInfo? TransactionInfo { get; set; }

    }
}
