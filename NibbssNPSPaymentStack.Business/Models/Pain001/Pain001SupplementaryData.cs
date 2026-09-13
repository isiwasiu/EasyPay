using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain001
{
    public class Pain001SupplementaryData
    {

        [XmlElement("PlcAndNm")]
        public string? PlaceAndName { get; set; }

        [XmlElement("Envlp")]
        public Pain001Envelope? Envelope { get; set; }

    }
}
