using NibbssNPSPaymentStack.Business.Models.Pacs008;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Camt060
{
    public class camt060Envelope
    {
        [XmlElement("CustomData")]
        public  camt060CustomData? CustomData { get; set; }

    }
}
