using NibbssNPSPaymentStack.Business.Models.Pacs008;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibbssNPSPaymentStack.Business.Models.Pain013
{
    public class Pain013CustomData
    {
        public DebtorInfo? DebtorInfo { get; set; }
        public Pain013DebtorMetadata? DebtorMetadata { get; set; }
        public CreditorInfo? CreditorInfo { get; set; }
        public Pain013TransactionInfo? TransactionInfo { get; set; }
    }
}
