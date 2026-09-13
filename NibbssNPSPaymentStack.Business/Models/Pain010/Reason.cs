using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain010
{
    public class Reason
    {
        [XmlElement(ElementName = "Cd")]
        public string? Cd { get; set; }

        [XmlElement(ElementName = "Prtry")]
        public string? Prtry { get; set; }
    }
}
