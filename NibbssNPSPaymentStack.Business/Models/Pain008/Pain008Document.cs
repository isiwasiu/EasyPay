using NibbssNPSPaymentStack.Business.Models.Pacs003;
using NibbssNPSPaymentStack.Business.Models.Pain001;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain008
{
    [XmlRoot("Document", Namespace = "urn:iso:std:iso:20022:tech:xsd:pain.008.001.11")]
    public class Pain008Document
    {
             [XmlElement("CstmrDrctDbtInitn")]
            public Pain008CstmrDrctDbtInitn CstmrDrctDbtInitn { get; set; }
        
    }
}
