using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibbssNPSPaymentStack.Business.Models.acmt023
{
    public class GetAccountVerificationViewModel
    {
        public long Id {  get; set; }
        public string? MessageId {  get; set; }
        public  string? AccountNo {  get; set; }
        public string? Status {  get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
