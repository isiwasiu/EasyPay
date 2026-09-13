using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Camt053
{
    public class BankToCustomerStatement
    {

        [XmlElement("GrpHdr")]
        public Camt053GrpHdr? GrpHdr { get; set; }

        [XmlElement("Stmt")]
        public Statement? Stmt { get; set; }

    }
}
