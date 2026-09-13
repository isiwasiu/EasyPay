using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain008
{
    public  class Pain008SplmtryData
    {
        [XmlAttribute("PlcAndNm")]
        public string? PlaceAndName  { get; set; }   

        public Pain008Envlp Envlp { get; set; }
    }
}
