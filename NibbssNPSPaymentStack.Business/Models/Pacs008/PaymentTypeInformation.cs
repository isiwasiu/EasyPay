using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pacs008
{
    [XmlRoot(ElementName = "PmtTpInf")]
    public class PaymentTypeInformation
    {
        [XmlElement(ElementName = "ClrChanl")]
        public string? ClrChanl { get; set; }

        [XmlElement(ElementName = "SvcLvl")]
        public SvcLvl? SvcLvl { get; set; }

        [XmlElement(ElementName = "LclInstrm")]
        public LclInstrm? LclInstrm { get; set; }

        [XmlElement(ElementName = "CtgyPurp")]
        public CtgyPurp? CtgyPurp { get; set; }
    }

    [XmlRoot(ElementName = "SvcLvl")]
    public class SvcLvl
    {

        [XmlElement(ElementName = "Prtry")]
        public string? Prtry { get; set; }
    }

    [XmlRoot(ElementName = "LclInstrm")]
    public class LclInstrm
    {
        [XmlElement(ElementName = "Prtry")]
        public string? Prtry { get; set; }
    }

    [XmlRoot(ElementName = "CtgyPurp")]
    public class CtgyPurp
    {

        [XmlElement(ElementName = "Prtry")]
        public string? Prtry { get; set; }
    }
}
