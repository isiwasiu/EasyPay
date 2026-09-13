using NibbssNPSPaymentStack.Business.Models.acmt023;
using NibbssNPSPaymentStack.Business.Models.Camt053;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Camt052
{
    public class Camt052Report
    {
        [XmlElement("Id")]
        public string? Id { get; set; }

        [XmlElement("FrToDt")]
        public FromToDateTime? FrToDt { get; set; }

        [XmlElement("Acct")]
        public Camt053Account? Acct { get; set; }

        [XmlElement("Bal")]
        public Balance? Bal { get; set; }

        [XmlElement("Ntry")]
        public List<Camt052Entry>? Ntry { get; set; }
    }
}
