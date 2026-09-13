using NibbssNPSPaymentStack.Business.Models.Pacs002;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pacs028
{
    [XmlRoot("Document", Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.028.001.06")]
    public class Pacs028Document
    {
        [XmlElement(ElementName = "FIToFIPmtStsReq", Namespace ="")]
        public FIToFIPmtStsReq? FIToFIPmtStsReq { get; set; }
    }
}
