using NibbssNPSPaymentStack.Business.Models.Pain001;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Camt053
{
    public class OtherId
    {
        [XmlElement("Id")]
        public string? Id  { get; set; }

        [XmlElement("SchmeNm")]
        public SchemeName? SchmeNm { get; set; }
    }
}
