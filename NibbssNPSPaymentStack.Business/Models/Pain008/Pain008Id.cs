using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain008
{
    public  class Pain008Id
    {
        [XmlElement("IBAN")] 
        public string? IBAN { get; set; }
        public Pain008Othr Othr { get; set; }   
     }
}
