using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NibssNPSPaymentStack.Data.Models.ModelView
{
    public class UsersSetup1
    {
        [Key]
        [MaxLength(50)]
        [JsonIgnore]
        public string UserId { get; set; } = Guid.NewGuid().ToString();

       
        [MaxLength(50)]
        [JsonIgnore]
        public string Username { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;


        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string ContactPhonenumber { get; set; }

        public string BusinessName { get; set; }
       
        
        [JsonIgnore]
        public string AllowedEndpoints { get; set; } = string.Empty;

        /// <summary>
        /// Store a hashed version of the API key (e.g., BCrypt, PBKDF2).
        /// Never store the plain API key in the database.
        /// </summary>
        [MaxLength(255)]
        [JsonIgnore]
        public string ApiKey { get; set; } = string.Empty;

        /// <summary>
        /// JSON serialized list of roles (e.g., ["admin", "developer", "readonly"]).
        /// Could also be a navigation property if using many-to-many.

        [Column(TypeName = "nvarchar(max)")]
        [JsonIgnore]
        public List<string> Roles { get; set; } = new() { "Readonly" };
        [JsonIgnore]
        public bool IsActive { get; set; } = false;



        // Rate limiting settings

        [JsonIgnore]
        public int RateLimitRequestsPerMinute { get; set; } = 60;

        [JsonIgnore]
        public int RateLimitBurst { get; set; } = 10;

        /// <summary>
        /// List of allowed API endpoint paths (e.g., ["/v1/orders", "/v2/products"]).
        /// Can be stored as JSON.
        /// </summary>



        [JsonIgnore]

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [JsonIgnore]
        public DateTime? LastAccessed { get; set; } = DateTime.UtcNow;

        // Optional: store additional metadata
        [MaxLength(500)]
        public string? Description { get; set; }
    }
}