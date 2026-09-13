using NibbssNPSPaymentStack.Business.Models.Pacs002;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain008
{
    public  class Pain008CstmrDrctDbtInitn
    {
        [XmlElement(ElementName = "GrpHdr")]
        public Pain008GrpHdr GrpHdr {  get; set; }

        [XmlElement(ElementName = "PmtInf")]
        public Pain008PmtInf PmtInf { get; set; }

        [XmlElement(ElementName = "SplmtryData")]
        public Pain008SplmtryData SplmtryData { get; set; }
    }
}
