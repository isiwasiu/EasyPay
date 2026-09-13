using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain001
{
    [XmlRoot("Document", Namespace = "urn:iso:std:iso:20022:tech:xsd:pain.001.001.12")]
    public class Pain001Document
    {

        [XmlElement("CstmrCdtTrfInitn",Namespace ="")]
        public CustomerCreditTransferInitiation? CustomerCreditTransferInitiation { get; set; }

    }
}
