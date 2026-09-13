using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibssNPSPaymentStack.Data.Models.Model
{
    public class IpWhitelistEntry
    {
        public int Id { get; set; }
        public string IpAddressOrRange { get; set; }  // e.g., "192.168.1.0/24" or single IP
        public string Description { get; set; }

        public int ApiKeyId { get; set; }
        public ApiKey ApiKey { get; set; }
    }
}