using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain013
{
    [XmlRoot(ElementName = "Document", Namespace = "urn:iso:std:iso:20022:tech:xsd:pain.013.001.11")]
    public class Pain013Document
    {
        [XmlElement(ElementName = "CdtrPmtActvtnReq", Namespace = "")]
        public CreditorPaymentActivationRequest? CreditorPaymentActivationRequest { get; set; }
    }
}
