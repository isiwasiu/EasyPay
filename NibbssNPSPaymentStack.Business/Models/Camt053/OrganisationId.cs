using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Camt053
{
    public class OrganisationId
    {
        [XmlElement("AnyBIC")]
        public string? AnyBIC { get; set; }

    }
}
