using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibbssNPSPaymentStack.Business.Models
{
    public  class TokenCache
    {
        public string AccessToken { get; set; }
        public DateTime ExpiryTime { get; set; }
        public bool IsValid => DateTime.UtcNow < ExpiryTime;
    }
}
