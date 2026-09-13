using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibbssNPSPaymentStack.Business.Models.Pacs003
{
    public class Pacs003TransactionInfo
    {
        public string? TransactionLocation { get; set; }
        public string? NameEnquiryMsgId { get; set; }
        public string? ChannelCode { get; set; }
        public string? RiskRating { get; set; }
        public bool FixedCollectionAmount { get; set; }
    }
}
