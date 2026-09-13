using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.acmt023
{
    public class Verification
    {
        [XmlElement("Id")]
        public string? Id { get; set; }

        [XmlElement("PtyAndAcctId")]
        public PartyAndAccountIdentification? PartyAndAccountId { get; set; }
    }
}
