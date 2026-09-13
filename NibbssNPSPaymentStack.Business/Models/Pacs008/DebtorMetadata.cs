using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pacs008
{
    [XmlRoot("DebtorMetadata")]
    public class DebtorMetadata
    {
        [XmlElement("AnyOtherData")]
        public string? AnyOtherData { get; set; }
    }
}
