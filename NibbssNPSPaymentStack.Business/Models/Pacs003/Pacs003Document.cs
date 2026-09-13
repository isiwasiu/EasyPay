using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pacs003
{
    [XmlRoot("Document", Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.003.001.11")]
    public class Pacs003Document
    {
        [XmlElement("FIToFICstmrDrctDbt", Namespace = "")]
        public FIToFICstmrDrctDbt? FIToFICstmrDrctDbt { get; set; }
    }
}
