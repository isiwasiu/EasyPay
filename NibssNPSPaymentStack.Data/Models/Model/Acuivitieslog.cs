using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibssNPSPaymentStack.Data.Models.Model
{
   
[Table("ActivitiesLog")]
    public class ActivitiesLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public long Id { get; set; }

        [Column("MessageId")]
        [MaxLength(100)]
        public string? MessageId { get; set; }  // Unique ID for this request (e.g., <MsgId>)

        [Column("CorrespondingMessageId")]
        [MaxLength(100)]
        public string? CorrespondingMessageId { get; set; }  // Links to a parent/related request

        [Column("ClientId")]
        [MaxLength(100)]
        public string? ClientId { get; set; }

        [Column("Endpoint")]
        [MaxLength(500)]
        public string? Endpoint { get; set; }

        [Column("RequestCategory")]
        [MaxLength(100)]
        public string? RequestCategory { get; set; }

        [Column("RequestDateTime")]
        public DateTimeOffset RequestDateTime { get; set; }

        [Column("ResponseDateTime")]
        public DateTimeOffset? ResponseDateTime { get; set; }

        [Column("Status")]
        [MaxLength(50)]
        public string? Status { get; set; }

        // --- Large payload fields ---

        [Column("Request", TypeName = "nvarchar(max)")]
        public string? Request { get; set; }

        [Column("RequestWithSignature", TypeName = "nvarchar(max)")]
        public string? RequestWithSignature { get; set; }

        [Column("EncryptedRequest", TypeName = "nvarchar(max)")]
        public string? EncryptedRequest { get; set; }

        [Column("EncryptedResponse", TypeName = "nvarchar(max)")]
        public string? EncryptedResponse { get; set; }

        [Column("Response", TypeName = "nvarchar(max)")]
        public string? Response { get; set; }

        [Column("clientIpAddress", TypeName = "nvarchar(max)")]
        public string? clientIpAddress { get; set; }  // Client's IP address


        [Column("UserAgent", TypeName = "nvarchar(max)")]
        public string? UserAgent { get; set; }  // Client's IP address


        [Column("Baseurl", TypeName = "nvarchar(150)")]
        public string? Baseurl { get; set; }  // Client's IP address



        [Column("Direction", TypeName = "nvarchar(50)")]
        public string? Direction { get; set; }  // Client's IP address




    }
}


