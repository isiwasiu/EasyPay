using NibbssNPSPaymentStack.Business.Models.Pacs008;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain008
{
    public  class Pain008CustomData
    {
        [XmlElement("DebtorInfo")]
        public Pain008DebtorInfo DebtorInfo {  get; set; }
       
        [XmlElement("DebtorMetadata")]
        public Pain008DebtorMetadata DebtorMetadata { get; set; }

        [XmlElement("CreditorInfo")] 
        public Pain008CreditorInfo CreditorInfo { get; set; }
      
        [XmlElement("CreditorMetadata")]
        public string CreditorMetadata { get; set; }

        [XmlElement("TransactionInfo")]
        public Pain008TransactionInfo TransactionInfo { get; set; }
    }
}
