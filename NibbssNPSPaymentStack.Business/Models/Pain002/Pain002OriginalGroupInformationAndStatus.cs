using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain002
{
    public class Pain002OriginalGroupInformationAndStatus
    {

        [XmlElement("OrgnlMsgId")]
        public string? OrgnlMsgId { get; set; }

        [XmlElement("OrgnlMsgNmId")]
        public string? OrgnlMsgNmId { get; set; }

        [XmlElement("GrpSts")]
        public string? GrpSts { get; set; }

    }
}
