using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pacs002
{
    [XmlRoot("Document", Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.002.001.12")]
    public class Pacs002Document
    {
        [XmlElement("FIToFIPmtStsRpt", Namespace = "")] 
        public FIToFIPmtStsRpt? FIToFIPmtStsRpt { get; set; }
    }
}
