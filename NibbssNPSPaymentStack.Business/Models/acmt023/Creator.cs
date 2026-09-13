using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.acmt023
{
    public class Creator
    {
        [XmlElement("Pty" , Namespace = "")]
        public Party? Party { get; set; }
    }

    public class Party
    {
        [XmlElement("Nm", Namespace = "")]
        public string? Name { get; set; }
    }

}
