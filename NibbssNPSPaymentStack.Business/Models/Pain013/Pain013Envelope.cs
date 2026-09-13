using NibbssNPSPaymentStack.Business.Models.Pacs008;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain013
{
    public class Pain013Envelope
    {

        [XmlElement("CustomData")]
        public Pain013CustomData? CustomData { get; set; }

    }
}
