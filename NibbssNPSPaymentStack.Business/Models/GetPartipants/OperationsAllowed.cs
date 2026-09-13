using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.GetPartipants
{
    public class OperationsAllowed
    {
        [XmlElement("operation")]
        public List<string>? Operation { get; set; }
    }
}
