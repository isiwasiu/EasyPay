using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace NibssNPSPaymentStack.Data.Models.Model
{
 
        public class UsersSetup
    {
        [Key]
        public string UserId { get; set; } = Guid.NewGuid().ToString();


      
        [MaxLength(50)]
        public string Username { get; set; } 


        public string Email { get; set; }


            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string ContactPhonenumber { get; set; }

            public string BusinessName { get; set; }



            public string AllowedEndpoints { get; set; } = string.Empty;

            /// <summary>
            /// Store a hashed version of the API key (e.g., BCrypt, PBKDF2).
            /// Never store the plain API key in the database.

            public string ApiKey { get; set; }

            /// <summary>
            /// JSON serialized list of roles (e.g., ["admin", "developer", "readonly"]).
            /// Could also be a navigation property if using many-to-many.


            public bool IsActive { get; set; } = false;





            public int RateLimitRequestsPerMinute { get; set; }


            public int RateLimitBurst { get; set; }

            /// <summary>
            /// List of allowed API endpoint paths (e.g., ["/v1/orders", "/v2/products"]).
            /// Can be stored as JSON.
            /// </summary>




            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

            public DateTime? ExpiredAt { get; set; } = DateTime.UtcNow;


            public string? Description { get; set; }
        }
    }

