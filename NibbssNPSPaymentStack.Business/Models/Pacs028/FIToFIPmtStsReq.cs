using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pacs028
{
    public class FIToFIPmtStsReq
    {
        [XmlElement(ElementName = "GrpHdr")]
        public Pacs028GrpHdr? GrpHdr { get; set; }

        [XmlElement(ElementName = "OrgnlGrpInf")]
        public OrgnlGrpInf? OrgnlGrpInf { get; set; }

        [XmlElement(ElementName = "TxInf")]
        public TxInf? TxInf { get; set; }
    }
}
