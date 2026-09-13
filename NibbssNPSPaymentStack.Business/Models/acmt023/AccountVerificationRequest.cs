using System.Text.Json.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.acmt023
{
    public class AccountVerificationRequest
    {
        [JsonIgnore]
        public string? InstitutionCode {  get; set; }

        [JsonIgnore]
        public DateTime CreatedAt { get; set; }

        [JsonIgnore]
        public string? MessageId {  get; set; }

        [JsonIgnore]
        public string? CreatorName {  get; set; }

        //requesting bank
        public string? RequestingBankName {  get; set; }
        public string? RequestingBankInstitudeCode {  get; set; }
        public string? RequestingCbnbankCode {  get; set; }

        //responsing bank
        public string? RespondingBankInstitudeCode { get; set; }
        public string? RespondingCbnbankCode { get; set; }

        //verify details
        [JsonIgnore]
        public string? VerifyID { get; set; }  // the same as messageId
        public string? AccountName {  get; set; }
        public string? AccountNo {  get; set; }
    }
}
