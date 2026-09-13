using NibbssNPSPaymentStack.Business.Models.acmt023;
using NibbssNPSPaymentStack.Business.Models.Pain009;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain012
{
    public class Pain012OriginalMandate
    {
        [XmlElement(ElementName = "Ocrncs", Namespace = "")]
        public Ocrncs? Ocrncs { get; set; }

        [XmlElement(ElementName = "TrckgInd", Namespace = "")]
        public bool TrckgInd { get; set; }

        [XmlElement(ElementName = "Cdtr", Namespace = "")]
        public Party? Cdtr { get; set; }

        [XmlElement(ElementName = "CdtrAcct", Namespace = "")]
        public Account? CdtrAcct { get; set; }

        [XmlElement(ElementName = "CdtrAgt", Namespace = "")]
        public Agent? CdtrAgt { get; set; }

        [XmlElement(ElementName = "Dbtr", Namespace = "")]
        public Party? Dbtr { get; set; }

        [XmlElement(ElementName = "DbtrAcct", Namespace = "")]
        public Account? DbtrAcct { get; set; }

        [XmlElement(ElementName = "DbtrAgt", Namespace = "")]
        public Agent? DbtrAgt { get; set; }
    }
}
