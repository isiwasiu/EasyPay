using NibbssNPSPaymentStack.Business.Models.Pacs008;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain008
{
    public  class Pain008PmtTpInf
    {
       public Pain008SvcLvl SvcLvl { get; set; }
        public Pain008LclInstrm LclInstrm { get; set; }

        [XmlElement("SeqTp")] 
        public string? SequenceType   { get; set; }
    }
}
