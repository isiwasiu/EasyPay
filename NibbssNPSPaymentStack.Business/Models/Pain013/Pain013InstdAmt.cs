using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain013
{
    public class Pain013InstdAmt
    {
        [XmlAttribute("Ccy")]
        public string? Ccy { get; set; }

        [XmlText]
        public decimal Value { get; set; }
    }
}
