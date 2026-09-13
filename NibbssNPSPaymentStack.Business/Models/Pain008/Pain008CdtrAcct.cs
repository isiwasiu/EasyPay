using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain008
{
    public  class Pain008CdtrAcct
    {
        [XmlElement("Id")] 
        public Pain008Id Id { get; set; }

        [XmlElement("Ccy")] 
        public string? Ccy {  get; set; }
    }
}
