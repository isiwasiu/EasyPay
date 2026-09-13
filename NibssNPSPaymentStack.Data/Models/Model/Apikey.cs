using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibssNPSPaymentStack.Data.Models.Model
{
   
    public class ApiKey
    {
        public int Id { get; set; }
        public string AppId { get; set; }          // Public identifier (e.g., "client_123")
        public string AppSecret { get; set; }       // Hashed shared secret (for signature verification)
        public string Name { get; set; }            // Friendly name
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }

        // Navigation
        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        public ICollection<IpWhitelistEntry> IpWhitelistEntries { get; set; }
        public ICollection<RateLimitRule> RateLimitRules { get; set; }
    }




}
