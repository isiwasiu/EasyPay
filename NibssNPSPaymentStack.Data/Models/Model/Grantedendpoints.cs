using NibbssNPSPaymentStack.API.Models.Model;
using NibssNPSPaymentStack.API.Models.Model;
using NibssNPSPaymentStack.Data.Models.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibssNPSPaymentStack.API.Models.Model
{

    public class Grantedendpoints
{

   
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string EndpointPath { get; set; } = string.Empty;  // e.g., "/v1/orders"

        [MaxLength(10)]
        public string? HttpMethod { get; set; }  // e.g., "GET", "POST" (optional)

        [MaxLength(500)]
        public string? Description { get; set; }

        // Foreign key to UsersSetup
        [Required]
        [MaxLength(50)]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public virtual UsersSetup? User { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

