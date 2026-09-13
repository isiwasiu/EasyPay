using NibbssNPSPaymentStack.Business.Models.acmt023;
using NibbssNPSPaymentStack.Business.Models.Pacs002;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pacs028
{
    public class TxInf
    {
        [XmlElement(ElementName = "StsReqId")]
        public string? StsReqId { get; set; }

        [XmlElement(ElementName = "OrgnlTxId")]
        public string? OrgnlTxId { get; set; }

        [XmlElement(ElementName = "InstgAgt")]
        public Agent? InstgAgt { get; set; }

        [XmlElement(ElementName = "InstdAgt")]
        public Agent? InstdAgt2 { get; set; }

        [XmlElement(ElementName = "OrgnlTxRef")]
        public OrgnlTxRef? OrgnlTxRef { get; set; }
    }
}
