using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NibbssNPSPaymentStack.Business.Models.Pain002
{
    public  class Pain002Request
    {
        // ---------- Internal fields (not serialized) ----------

        /// <summary>
        /// Unique message ID for this status report.
        /// Maps to GrpHdr.MsgId.
        /// </summary>
        [JsonIgnore]
        public string? MssgId { get; set; }

        /// <summary>
        /// Creation date/time of this report.
        /// Maps to GrpHdr.CreDtTm.
        /// </summary>
        [JsonIgnore]
        public DateTime CreateAt { get; set; }

        /// <summary>
        /// Optional internal tracking flag (e.g., used to mark invalid data).
        /// </summary>
        [JsonIgnore]
        public bool InvalidAccount { get; set; }

        // ---------- Public fields (serialized to/from JSON) ----------

        /// <summary>
        /// Sender institution code (if applicable – not standard in pain.002 but included for consistency).
        /// </summary>
        public string? SenderInstitutionCode { get; set; }

        /// <summary>
        /// Receiving institution code (if applicable).
        /// </summary>
        public string? ReceivingInstitutionCode { get; set; }

        /// <summary>
        /// The original message ID of the payment instruction (pain.001) that this report refers to.
        /// Maps to OrgnlGrpInfAndSts.OrgnlMsgId.
        /// </summary>
        public string? OriginalMessageId { get; set; }

        /// <summary>
        /// The original creation date/time of the payment instruction.
        /// Maps to OrgnlGrpInfAndSts.OrgnlCreDtTm (optional).
        /// </summary>
        public DateTime? OriginalCreationDateTime { get; set; }

        /// <summary>
        /// Group‑level status (e.g., "ACTC", "RJCT", "ACSC").
        /// Maps to OrgnlGrpInfAndSts.GrpSts.
        /// </summary>
        public string? GroupStatus { get; set; }

        /// <summary>
        /// Additional information about the status (reason, narrative).
        /// Maps to StsRsnInf.AddtlInf (concatenated if multiple).
        /// </summary>
        public string? StatusReason { get; set; }

        // ------- Optional: if you need transaction‑level details -------

        /// <summary>
        /// Original payment information ID (if you need to reference a specific payment block).
        /// </summary>
        public string? OriginalPaymentInformationId { get; set; }

        /// <summary>
        /// Original end‑to‑end ID (transaction reference).
        /// </summary>
        public string? EndToEndId { get; set; }

        /// <summary>
        /// Transaction status (if reporting at transaction level).
        /// </summary>
        public string? TransactionStatus { get; set; }
    }
}
