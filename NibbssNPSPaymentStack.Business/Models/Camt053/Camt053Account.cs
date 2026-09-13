using NibbssNPSPaymentStack.Business.Models.acmt023;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Camt053
{
    public class Camt053Account
    {
        [XmlElement("Id")]
        public AccountId? Id { get; set; }

        [XmlElement("Ccy")]
        public string? Ccy { get; set; }

        [XmlElement("Ownr")]
        public Owner? Ownr { get; set; }

        [XmlElement("Svcr")]
        public Servicer? Svcr { get; set; }
    }
}
