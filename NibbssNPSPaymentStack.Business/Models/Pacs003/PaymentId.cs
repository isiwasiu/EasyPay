using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibbssNPSPaymentStack.Business.Models.Pacs003
{
    public class PaymentId
    {
        public string? InstrId { get; set; }
        public string? EndToEndId { get; set; }
        public string? TxId { get; set; }
    }
}
