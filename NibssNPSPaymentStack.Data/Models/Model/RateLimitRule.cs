using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibssNPSPaymentStack.Data.Models.Model
{
    public class RateLimitRule
    {
        public int Id { get; set; }
        public string EndpointPattern { get; set; }   // e.g., "/api/orders" (supports wildcard?)
        public int LimitPerMinute { get; set; }
        public int LimitPerHour { get; set; }
        // Could add more granular periods

        public int ApiKeyId { get; set; }
        public ApiKey ApiKey { get; set; }
    }
}
