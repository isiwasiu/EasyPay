using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain013
{
    public class RequestedExecutionDate
    {
        [XmlElement("DtTm")]
        public DateTime DateTime { get; set; }

    }
}
