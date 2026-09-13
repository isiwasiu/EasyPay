using NibbssNPSPaymentStack.Business.Models.acmt023;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibbssNPSPaymentStack.Business.Models.Pain013
{
    public class Pain013CreditTransferTransaction
    {
        public PmtId? PmtId { get; set; }
        public Pain013Amount? Amt { get; set; }
        public Agent? CdtrAgt { get; set; }
        public Party? Cdtr { get; set; }
        public Pain013Account? CdtrAcct { get; set; }
        public Purp? Purp { get; set; }
    }

    
}
