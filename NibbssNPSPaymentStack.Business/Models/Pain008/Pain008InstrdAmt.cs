using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain008
{
    public  class Pain008InstrdAmt
    {

        [XmlAttribute("Ccy")]
        public string? Ccy { get; set; }

        [XmlText]
        public double Value { get; set; }
    }
}
