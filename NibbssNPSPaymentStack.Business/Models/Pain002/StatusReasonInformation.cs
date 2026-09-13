using NibbssNPSPaymentStack.Business.Models.Pain010;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain002
{
    public class StatusReasonInformation
    {

        [XmlElement("Rsn")]
        public Reason? Rsn { get; set; }

        [XmlElement("AddtlInf")]
        public string? AddtlInf { get; set; }

    }
}
