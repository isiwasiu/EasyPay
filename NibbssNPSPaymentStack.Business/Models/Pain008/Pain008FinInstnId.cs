using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain008
{
    public class Pain008FinInstnId
    {
        [XmlElement(ElementName = "BICFI")]
        public string? BICFI { get; set; }

        public Pain008ClrSysMmbId ClrSysMmbId { get; set; }
    }
}
