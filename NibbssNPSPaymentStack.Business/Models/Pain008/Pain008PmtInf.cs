using NibbssNPSPaymentStack.Business.Models.Pacs008;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain008
{
    public  class Pain008PmtInf
    {
        [XmlElement("PmtInfId")]  
        public string? PmtInfId {  get; set; }
       
        [XmlElement("PmtMtd")] 
        public string? PmtMtd { get; set; }

        [XmlElement("NbOfTx")] 
        public string? NbOfTx { get; set; }


        [XmlElement("CtrlSum")]  
        public string? PmtInfControlSum { get; set; }



        [XmlElement("PmtTpInf")]
        public Pain008PmtTpInf PmtTpInf { get; set; }

        [XmlElement("ReqdColltnDt")] 
        public DateTime? RequestedCollectionDate { get; set; }

      //  <!-- Creditor(payee) information -->
        [XmlElement("Cdtr")] 
        public Pain008Cdtr?  Cdtr { get; set; }
        [XmlElement("CdtrAcct")]
        public Pain008CdtrAcct? CdtrAcct { get; set; }

      

        [XmlElement("CdtrAgt")] 
        public Pain008CdtrAgt? CdtrAgt { get; set; }



        [XmlElement("DrctDbtTxInf")] 
        public Pain008DrctDbtTxInf?  DrctDbtTxInf { get; set; }

        
    }
}
