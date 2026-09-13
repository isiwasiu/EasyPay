using NibbssNPSPaymentStack.Business.Models.Pacs002;
using NibbssNPSPaymentStack.Business.Models.Pain009;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pacs003
{
    public class FIToFICstmrDrctDbt
    {
        [XmlElement(ElementName = "GrpHdr")]
        public Pacs003GrpHdr? GrpHdr { get; set; }

        [XmlElement(ElementName = "DrctDbtTxInf")]
        public DirectDebitTransactionInfo? DrctDbtTxInf { get; set; }

        [XmlElement(ElementName = "SplmtryData")]
        public Pacs003SplmtryData? SplmtryData { get; set; }
    }
}
