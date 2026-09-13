using NibbssNPSPaymentStack.Business.Models.Pacs008;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain001
{
    public class Pain001Envelope
    {

        [XmlElement("CustomData")]
        public Pain001CustomData? CustomData { get; set; }

    }
}
