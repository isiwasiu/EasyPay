using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain012
{
   
    public class Pain012GrpHdr
    {
        [XmlElement(ElementName = "MsgId",Namespace ="")]
        public string? MsgId { get; set; }

        [XmlElement(ElementName = "CreDtTm", Namespace = "")]
        public DateTime CreDtTm { get; set; }
    }
}
