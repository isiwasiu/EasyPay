using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NibbssNPSPaymentStack.Business.Models.acmt024
{
    public class AccountVerificationStatusRequest
    {
        [JsonIgnore]
        public string? MssgId { get; set; }

        [JsonIgnore]
        public DateTime CreatedAt {  get; set; }

        public string? SendingInstitutionCode {  get; set; }
        public string? ReceiverInstitutionName { get;set; }
        public string? ReceiverInstitutionCode { get;set; }
        public string? nameEquiryMssgId{ get; set; }
        public DateTime nameEquiryDate { get; set; }

        [JsonIgnore]
        public string? OriginalMssgId { get; set; }//the same mssgid
        public bool Verification {  get; set; }
        public string? FailureReasonCode {  get; set; } // if acmt023 is unsuccessful
        public string? FailureReasonDescription {  get; set; }
        public string? VerifiedAccountNo { get; set; }
        public string? AccountName {  get; set; }
        public string? AccountDesignation {  get; set; }
        public string? AccountIdType {  get; set; }
        public string? AccountIdValue {  get; set; }
        public string? AccountTier {  get; set; }
        public string? RiskRating { get; set; }
    }
}
