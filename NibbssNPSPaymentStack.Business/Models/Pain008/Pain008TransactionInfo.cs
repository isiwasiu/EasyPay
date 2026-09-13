using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain008
{
    public class Pain008TransactionInfo
    {

        [XmlElement("TransactionLocation")] 
        public string? TransactionLocation { get; set; }

        [XmlElement("NameEnquiryMsgId")] 
        public string? NameEnquiryMsgId { get; set; }

        [XmlElement("ChannelCode")] 
        public string? ChannelCode { get; set; }

        [XmlElement("FixedCollectionAmount")] 
        public bool? FixedCollectionAmount { get; set; }

        [XmlElement("MandateCode")] 
        public string? MandateCode { get; set; }
    }
}
