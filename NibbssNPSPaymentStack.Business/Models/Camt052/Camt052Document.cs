using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Camt052
{
    [XmlRoot("Document", Namespace = "urn:iso:std:iso:20022:tech:xsd:camt.052.001.12")]
    public class Camt052Document
    {

        [XmlElement("BkToCstmrAcctRpt", Namespace = "")]
        public BankToCustomerAccountReport? BkToCstmrAcctRpt { get; set; }

    }
}