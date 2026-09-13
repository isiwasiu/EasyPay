using NibbssNPSPaymentStack.Business.Models.Pain009;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pacs003
{
    public class MndtRltdInf
    {   
        public string? MndtId { get; set; }
        public DateTime DtOfSgntr { get; set; }
        public string? FrstColltnDt { get; set; }
        public string? FnlColltnDt { get; set; }
        public Frqcy? Frqcy { get; set; }
    }
}
