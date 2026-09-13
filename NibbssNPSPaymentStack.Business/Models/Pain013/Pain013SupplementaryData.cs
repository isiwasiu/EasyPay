using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain013
{
    public class Pain013SupplementaryData
    {

        [XmlElement("PlcAndNm")]
        public string? PlaceAndName { get; set; }

        [XmlElement("Envlp")]
        public Pain013Envelope? Envelope { get; set; }

    }
}
