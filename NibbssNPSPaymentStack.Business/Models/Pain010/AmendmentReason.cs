using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain010
{
    public class AmendmentReason
    {
        [XmlElement(ElementName = "Rsn")]
        public Reason? Rsn { get; set; }
    }
}
