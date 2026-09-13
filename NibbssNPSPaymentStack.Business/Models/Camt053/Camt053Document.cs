using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Camt053
{
    [XmlRoot("Document", Namespace = "urn:iso:std:iso:20022:tech:xsd:camt.053.001.12")]
    public class Camt053Document
    {
        [XmlElement("BkToCstmrStmt", Namespace = "")]
        public BankToCustomerStatement? BkToCstmrStmt { get; set; }

    }
}
