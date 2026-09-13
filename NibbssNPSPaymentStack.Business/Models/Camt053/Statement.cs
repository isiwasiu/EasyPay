using NibbssNPSPaymentStack.Business.Models.acmt023;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Camt053
{
    public class Statement
    {

        [XmlElement("Id")]
        public string? Id { get; set; }

        [XmlElement("FrToDt")]
        public FromToDateTime? FrToDt { get; set; }

        [XmlElement("Acct")]
        public Camt053Account? Acct { get; set; }

        [XmlElement("Bal")]
        public List<Balance>? Bal { get; set; }

        [XmlElement("Ntry")]
        public List<Entry>? Ntry { get; set; }

    }
}
