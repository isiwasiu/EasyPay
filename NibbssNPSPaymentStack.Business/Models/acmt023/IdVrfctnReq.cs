using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.acmt023
{
    public class IdVrfctnReq
    {
        [XmlElement("Assgnmt", Namespace = "")]
        public Assignment? Assignment { get; set; }

        [XmlElement("Vrfctn", Namespace = "")]
        public Verification? Verification { get; set; }
    }
}
