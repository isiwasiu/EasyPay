
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Camt053
{
    public  class Sts
    {
        [XmlElement("Prtry")]
        public string? Prtry { get; set; }
    }
}
