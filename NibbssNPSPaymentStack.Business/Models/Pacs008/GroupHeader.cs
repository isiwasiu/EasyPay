using NibbssNPSPaymentStack.Business.Models.acmt023;
using NibbssNPSPaymentStack.Business.Models.Pacs002;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pacs008
{
    public class GroupHeader
    {
        [XmlElement("MsgId")]
        public string? MsgId { get; set; }

        [XmlElement("CreDtTm")]
        public DateTime CreDtTm { get; set; }

        [XmlElement("BtchBookg")]
        public bool BtchBookg { get; set; }

        [XmlElement("NbOfTxs")]
        public int NbOfTxs { get; set; }

        [XmlElement("SttlmInf")]
        public SettlementInformation? SttlmInf { get; set; }

        [XmlElement("InstgAgt")]
        public Agent? InstgAgt { get; set; }

        [XmlElement("InstdAgt")]
        public Agent? InstdAgt2 { get; set; }
    }

    public class Pac002GroupHeader
    {
        [XmlElement("MsgId")]
        public string? MsgId { get; set; }

        [XmlElement("CreDtTm")]
        public DateTime CreDtTm { get; set; }

        [XmlElement("InstgAgt")]
        public Agent? InstgAgt { get; set; }

        [XmlElement("InstdAgt")]
        public Agent? InstdAgt2 { get; set; }
    }

}
