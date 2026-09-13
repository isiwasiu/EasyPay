using System.ComponentModel.DataAnnotations;

namespace NibbssNPSPaymentStack.API.Models.Model
{
    public class AvailiableEndpoints
    {
      

            public int Id { get; set; }

            [Required]
            [MaxLength(10)]
            public string HttpMethod { get; set; } = "GET"; // Required

            [Required]
            [MaxLength(500)]
            public string RouteTemplate { get; set; } = string.Empty; // e.g., "/v1/orders/{id}"

            [MaxLength(500)]
            public string? Description { get; set; }

            [MaxLength(200)]
            public string? Handler { get; set; } // e.g., "OrdersController.GetOrder"

            [MaxLength(100)]
            public string? Version { get; set; } // e.g., "1.0"

            public bool IsDeprecated { get; set; }
            public bool IsEnabled { get; set; } = true;

            // Optional: store route parameter definitions as JSON
            public string? RouteParametersJson { get; set; }

            [MaxLength(50)]
            public string? RequiredRole { get; set; }

        public string?  Baseurl  { get; set; }

    }
   
}
