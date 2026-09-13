using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pain008
{
    public  class Pain008DrctDbtTxInf
    {
        public Pain008PmtId PmtId { get; set; }

        public Pain008InstrdAmt InstdAmt { get; set; }

        public Pain008DrctDbtTx DrctDbtTx { get; set; }
      
        public  Pain008DbtrAgt DbtrAgt { get; set; }

        public Pain008Dbtr Dbtr { get; set; }

        public Pain008DbtrAcct DbtrAcct { get; set; }

    public Pain008RmtInf RmtInf { get; set; }


     }
}

