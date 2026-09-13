using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.acmt023
{
    public class PartyAndAccountIdentification
    {
        [XmlElement("Pty")]
        public Party? Party { get; set; }

        [XmlElement("Acct")]
        public Account? Account { get; set; }
    }
}
