using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.acmt023
{


    [XmlRoot("Document", Namespace = Ns)]
    public class acmt023Document
    {
        public const string Ns = "urn:iso:std:iso:20022:tech:xsd:acmt.023.001.04";

        [XmlElement("IdVrfctnReq", Namespace = "")]
        public IdVrfctnReq? IdVrfctnReq { get; set; }
    }
}
