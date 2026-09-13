using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain014
{
    public class OriginalGroupInformationAndStatus
    {

        [XmlElement("OrgnlMsgId")]
        public string? OriginalMessageId { get; set; }

        [XmlElement("OrgnlMsgNmId")]
        public string? OriginalMessageNameId { get; set; }

        [XmlElement("OrgnlCreDtTm")]
        public DateTime OriginalCreationDateTime { get; set; }

        [XmlElement("GrpSts")]
        public string? GroupStatus { get; set; }

    }
}
