using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Camt060
{
    public class ReportingPeriod
    {

        [XmlElement("FrToDt")]
        public FromToDate? FromToDate { get; set; }

        [XmlElement("Tp")]
        public string? Type { get; set; }

    }
}
