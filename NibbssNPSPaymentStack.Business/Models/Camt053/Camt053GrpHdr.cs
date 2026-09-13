using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Camt053
{
    public class Camt053GrpHdr
    {

        [XmlElement("MsgId")]
        public string? MsgId { get; set; }

        [XmlElement("CreDtTm")]
        public DateTime CreDtTm { get; set; }

        [XmlElement("MsgRcpt")]
        public MessageRecipient? MsgRcpt { get; set; }

        [XmlElement("OrgnlBizQry")]
        public OriginalBusinessQuery? OrgnlBizQry { get; set; }


    }
}
