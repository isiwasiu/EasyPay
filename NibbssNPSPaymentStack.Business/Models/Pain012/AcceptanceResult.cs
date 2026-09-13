using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain012
{
    public class AcceptanceResult
    {
        [XmlElement(ElementName = "Accptd")]
        public bool Accptd { get; set; }

        //[XmlElement(ElementName = "RjctRsn", Namespace = "")]
        //public Pain012RejectedReason? RjctRsn { get; set; }
    }
}
