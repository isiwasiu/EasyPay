using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Camt060
{
    public class Camt060GrpHdr
    {

        [XmlElement("MsgId")]
        public string? MessageId { get; set; }

        [XmlElement("CreDtTm")]
        public DateTime? CreationDateTime { get; set; }

        [XmlElement("MsgSndr")]
        public MessageSender? MessageSender { get; set; }

    }
}
