using NibbssNPSPaymentStack.Business.Models.acmt023;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Camt053
{
    public class Balance
    {
        [XmlElement("Tp")]
        public BalanceType? Tp { get; set; }

        [XmlElement("Amt")]
        public Amount? Amt { get; set; }

        [XmlElement("CdtDbtInd")]
        public string? CdtDbtInd { get; set; }

        [XmlElement("Dt", Namespace = "")]
        public BalanceDate? Dt { get; set; }
    }
}
