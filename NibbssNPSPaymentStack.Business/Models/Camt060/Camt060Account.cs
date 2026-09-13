using NibbssNPSPaymentStack.Business.Models.acmt023;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Camt060
{
    public class Camt060Account
    {

        [XmlElement("Id")]
        public AccountId? Id { get; set; }

        [XmlElement("Ccy")]
        public string? Currency { get; set; }

    }
}
