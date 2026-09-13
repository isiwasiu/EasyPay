using NibbssNPSPaymentStack.Business.Models.acmt023;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pacs028
{
    public class Pacs028GrpHdr
    {
        [XmlElement("MsgId")]
        public string? MsgId { get; set; }

        [XmlElement("CreDtTm")]
        public DateTime CreDtTm { get; set; }

        [XmlElement("InstgAgt")]
        public Agent? InstgAgt { get; set; }
    }
}
