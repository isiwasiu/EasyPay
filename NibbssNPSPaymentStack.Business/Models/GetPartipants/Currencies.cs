using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.GetPartipants
{
    public class Currencies
    {
        [XmlElement("currency")]
        public List<string>? Currency { get; set; }
    }
}
