using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Camt060
{
    public class FromToDate
    {

        [XmlElement("FrDt")]
        public string? FromDate { get; set; }

        [XmlElement("ToDt")]
        public string? ToDate { get; set; }
    }
}
