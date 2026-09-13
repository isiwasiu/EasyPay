using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Camt060
{
    public class Camt060SupplementaryData
    {

        [XmlElement("PlcAndNm")]
        public string? PlaceAndName { get; set; }

        [XmlElement("Envlp")]
        public camt060Envelope? Envelope { get; set; }

    }
}
