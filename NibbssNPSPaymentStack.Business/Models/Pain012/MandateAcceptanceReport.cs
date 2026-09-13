using NibbssNPSPaymentStack.Business.Models.Pacs008;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain012
{
    
    public class MandateAcceptanceReport
    {
        [XmlElement(ElementName = "GrpHdr",Namespace ="")]
        public Pain012GrpHdr? GrpHdr { get; set; }

        [XmlElement(ElementName = "UndrlygAccptncDtls",Namespace ="")]
        public UnderlyingAcceptanceDetails? UndrlygAccptncDtls { get; set; }
    }
}

