using NibbssNPSPaymentStack.Business.Models.Pain010;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain008
{
    public  class Pain008GrpHdr
    {
        [XmlElement("MsgId")]
        public string MsgId { get; set; }

        [XmlElement("CreDtTm")]
        public DateTime? CreDtTm { get; set; }

        [XmlElement("NbOfTxs")]
        public string NbOfTxs { get; set; }

        [XmlElement("CtrlSum")]
        public string CtrlSum { get; set; }

        [XmlElement("InitgPty")]
        public Pain008InitgPty InitgPty { get; set; }

        [XmlElement("FwdgAgt")]
        public Pain008FwdgAgt FwdgAgt { get; set; }
    }
}
