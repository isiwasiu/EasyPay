using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain002
{
    [XmlRoot("Document", Namespace = "urn:iso:std:iso:20022:tech:xsd:pain.002.001.14")]
    public class Pain002Document
    {
        [XmlElement("CstmrPmtStsRpt")]
        public CustomerPaymentStatusReport? CstmrPmtStsRpt { get; set; }

    }
}
