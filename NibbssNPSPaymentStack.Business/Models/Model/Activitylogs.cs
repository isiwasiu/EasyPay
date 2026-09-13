using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace NibbssNPSPaymentStack.Business.Models.Model
{
[Table("ActivityLogs")]
    public class ActivityLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        // Message identifier (e.g., GUID or unique request ID)
        [Required]
        [MaxLength(36)]
        public string? MessageId { get; set; }

        // Original request endpoint
        [Required]
        [MaxLength(500)]
        public string? RequestEndpoint { get; set; }

        // Plain request payload (could be JSON, XML, etc.)
        [Column(TypeName = "nvarchar(max)")]
        public string?  Request { get; set; }

        // Encrypted version of the request (for security/audit)
        [Column(TypeName = "nvarchar(max)")]
        public string? EncryptedRequest { get; set; }

        // Timestamp when the request was received
        [Required]
        public DateTime RequestTime { get; set; } = DateTime.UtcNow;

        // Plain response payload
        [Column(TypeName = "nvarchar(max)")]
        public string? Response { get; set; } 

        // Encrypted version of the response
        [Column(TypeName = "nvarchar(max)")]
        public string? EncryptedResponse { get; set; }

        // Timestamp when the response was sent
        public DateTime? ResponseTime { get; set; }

        // Callback request payload (if any)
        [Column(TypeName = "nvarchar(max)")]
        public string? CallbackRequest { get; set; }

        // Timestamp when the callback was triggered
        public DateTime? CallbackTime { get; set; }

        // Callback endpoint URL
        [MaxLength(500)]
        public string? CallbackEndpoint { get; set; }

        // Status of the original request (e.g., "Success", "Failed", "Pending")
        [Required]
        [MaxLength(50)]
        public string? RequestStatus { get; set; }

        // Status of the callback (e.g., "Sent", "Failed", "Retry", "NotRequired")
        [MaxLength(50)]
        public string? CallbackStatus { get; set; }
    }
}

