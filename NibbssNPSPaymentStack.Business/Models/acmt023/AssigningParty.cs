using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.acmt023
{
   
    public class AssigningParty
    {
        [XmlElement("Pty")]
        public Party? Party { get; set; }

        [XmlElement("Agt")]
        public Agent? Agent { get; set; }
    }

    public class AssignedParty
    {
        [XmlElement("Agt", Namespace = "")]
        public Agent? Agent { get; set; }
    }

}
