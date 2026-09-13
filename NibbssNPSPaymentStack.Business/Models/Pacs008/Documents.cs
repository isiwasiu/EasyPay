
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pacs008
{
    [XmlRoot("Document", Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.12")]
    public class Documents
    {
        [XmlElement("FIToFICstmrCdtTrf", Namespace ="")]
        public FIToFICustomerCreditTransfer? FIToFICstmrCdtTrf { get; set; }
    }
}

