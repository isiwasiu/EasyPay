using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Camt053
{
    public class OriginalBusinessQuery
    {
        [XmlElement("MsgId")]
        public string? MsgId { get; set; }

        [XmlElement("MsgNmId")]
        public string? MsgNmId { get; set; }

        [XmlElement("CreDtTm")]
        public DateTime? CreDtTm { get; set; }

    }
}
