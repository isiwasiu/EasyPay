using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pacs008
{
    public class FIToFICustomerCreditTransfer
    {
        [XmlElement("GrpHdr")]
        public GroupHeader? GrpHdr { get; set; }

        [XmlElement("CdtTrfTxInf")]
        public CreditTransferTransaction? CdtTrfTxInf { get; set; }

        [XmlElement("SplmtryData")]
        public SupplementaryData? SplmtryData { get; set; }
    }
}
