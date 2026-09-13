using NibbssNPSPaymentStack.Business.Models.Pacs008;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibbssNPSPaymentStack.Business.Models.Pacs003
{
    public class Pacs003CustomData
    {
        public DebtorInfo? DebtorInfo { get; set; }
        public Pacs003DebtorMetadata? DebtorMetadata { get; set; }
        public CreditorInfo? CreditorInfo { get; set; }
        public CreditorMetadata? CreditorMetadata { get; set; }
        public Pacs003TransactionInfo? TransactionInfo { get; set; }
    }
}
