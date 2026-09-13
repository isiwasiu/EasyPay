using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain002
{
    public class Pain002TransactionInformationAndStatus
    {

        [XmlElement("StsId")]
        public string? StsId { get; set; }

        [XmlElement("OrgnlEndToEndId")]
        public string? OrgnlEndToEndId { get; set; }

        [XmlElement("TxSts")]
        public string? TxSts { get; set; }

        [XmlElement("StsRsnInf")]
        public Pain002StatusReasonInformation? StsRsnInf { get; set; }

    }
}
