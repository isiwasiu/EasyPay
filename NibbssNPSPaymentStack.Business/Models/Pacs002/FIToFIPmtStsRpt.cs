using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pacs002
{
    public class FIToFIPmtStsRpt
    {
        [XmlElement(ElementName = "GrpHdr")]
        public GrpHdr? GrpHdr { get; set; }

        [XmlElement(ElementName = "OrgnlGrpInfAndSts")]
        public Pacs002OrgnlGrpInfAndSts? OrgnlGrpInfAndSts { get; set; }

        [XmlElement(ElementName = "TxInfAndSts")]
        public Pacs002TxInfAndSts? TxInfAndSts { get; set; }
    }
}
