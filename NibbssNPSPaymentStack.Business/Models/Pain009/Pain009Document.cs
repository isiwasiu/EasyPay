using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain009
{
    [XmlRoot("Document", Namespace = Ns)]
    public class Pain009Document
    {
        public const string Ns = "urn:iso:std:iso:20022:tech:xsd:pain.009.001.08";

        [XmlElement("MndtInitnReq", Namespace = "")]
        public MndtInitnReq? MndtInitnReq { get; set; }
    }
}
