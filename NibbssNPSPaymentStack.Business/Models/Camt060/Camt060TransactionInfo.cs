using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Camt060
{
    public class Camt060TransactionInfo
    {
        [XmlElement("TransactionLocation")]
        public string? TransactionLocation { get; set; }

        [XmlElement("ChannelCode")]
        public int ChannelCode { get; set; }

        [XmlElement("FixedCollectionAmount")]
        public bool FixedCollectionAmount { get; set; }

        [XmlElement("MandateCode")]
        public string? MandateCode { get; set; }

    }

}