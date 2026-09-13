using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pacs008
{
    public class ActiveCurrencyAndAmount
    {
        [XmlAttribute("Ccy")]
        public string? Ccy { get; set; }

        [XmlText]
        public decimal Value { get; set; }
    }
}
