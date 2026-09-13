using NibbssNPSPaymentStack.Business.Models.acmt023;
using NibbssNPSPaymentStack.Business.Models.Pain009;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain010
{
    public class Mandate
    {
        [XmlElement(ElementName = "MndtId")]
        public string? MndtId { get; set; }

        [XmlElement(ElementName = "Ocrncs")]
        public Ocrncs? Ocrncs { get; set; }

        [XmlElement(ElementName = "TrckgInd")]
        public bool TrckgInd { get; set; }

        [XmlElement(ElementName = "Cdtr")]
        public Party? Cdtr { get; set; }

        [XmlElement(ElementName = "CdtrAcct")]
        public Account? CdtrAcct { get; set; }

        [XmlElement(ElementName = "CdtrAgt")]
        public Agent? CdtrAgt { get; set; }

        [XmlElement(ElementName = "Dbtr")]
        public Party? Dbtr { get; set; }

        [XmlElement(ElementName = "DbtrAcct")]
        public Account? DbtrAcct { get; set; }

        [XmlElement(ElementName = "DbtrAgt")]
        public Agent? DbtrAgt { get; set; }
    }
}
