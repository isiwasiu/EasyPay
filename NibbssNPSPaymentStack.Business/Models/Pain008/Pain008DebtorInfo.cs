using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain008
{
    public  class Pain008DebtorInfo
    {
        [XmlElement("AccountDesignation")]
        public string? AccountDesignation {  get; set; }
        [XmlElement("IdType")]
        public string? IdType  { get; set; }

        [XmlElement("IdValue")]
        public string? IdValue  { get; set; }
        [XmlElement("AccountTier")] 
        public string? AccountTier  { get; set; }
    }
}
