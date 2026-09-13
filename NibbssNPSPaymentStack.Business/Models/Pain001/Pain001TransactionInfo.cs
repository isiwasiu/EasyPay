using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibbssNPSPaymentStack.Business.Models.Pain001
{
    public class Pain001TransactionInfo
    {
        public string? TransactionLocation { get; set; }
        public int ChannelCode { get; set; }
        public bool FixedCollectionAmount { get; set; }
        public string? MandateCode { get; set; }
    }

}