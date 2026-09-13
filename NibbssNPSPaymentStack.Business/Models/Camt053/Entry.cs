using NibbssNPSPaymentStack.Business.Models.Camt052;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Camt053
{
    public class Entry
    {
        [XmlElement("Amt")]
        public Amount? Amt { get; set; }

        [XmlElement("CdtDbtInd")]
        public string? CdtDbtInd { get; set; }

        [XmlElement("BookgDt")]
        public BookingDate? BookgDt { get; set; }

        [XmlElement("ValDt")]
        public ValueDate? ValDt { get; set; }

        [XmlElement("AcctSvcrRef")]
        public string? AcctSvcrRef { get; set; }

        public BkTxCd? BkTxCd {  get; set; }
        public NtryDtls? NtryDtls { get; set; }

        public Sts?  Sts { get; set; }
    }
}
