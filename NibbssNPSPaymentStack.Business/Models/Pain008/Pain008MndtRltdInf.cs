using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain008
{
    public  class Pain008MndtRltdInf
    {
        [XmlElement("MndtId")] 
        public string? MndtId { get; set; }
        
        [XmlElement("DtOfSgntr")] 
        public DateTime? DateOfSignature  { get; set; }
       
        [XmlElement("FrstColltnDt")] 
        public DateTime? FirstCollectionDate { get; set; }
       
        [XmlElement("FnlColltnDt")] 
        public DateTime? FinalCollectionDate { get; set; }
        public Pain008Frqcy Frqcy { get; set; }

    }
}
