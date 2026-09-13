using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibbssNPSPaymentStack.Business.Models.Pain009
{
    public class Pain009TransactionInfo
    {
        public string? TransactionLocation { get; set; }
        public int ChannelCode { get; set; }
        public string? MandateCategory { get; set; }
        public bool FixedCollectionAmount { get; set; }
    }
}
