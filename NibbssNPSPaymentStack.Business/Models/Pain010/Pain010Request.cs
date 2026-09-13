using System.Text.Json.Serialization;


namespace NibbssNPSPaymentStack.Business.Models.Pain010
{
    public class Pain010Request
    {
        [JsonIgnore]
        public string? MessageId {  get; set; }

        [JsonIgnore]
        public DateTime CreateAt { get; set; }
        public string? MandateInitiatingPartyName {  get; set; }
        public string? MandateMessageId {  get; set; }
        public DateTime MandateDate {  get; set; }

        [JsonIgnore]
        public string? MandateNameSpace { get; set; }
        public string? ReasonCode { get; set; }
        public string? ReasonDescription {  get; set; }
        public string? MandateId {  get; set; }
        public string? MandateSequenceType {  get; set; }
        public string? MandateFrequencyType {  get; set; }
        public DateTime MandateFirstCollectionDate {  get; set; }
        public DateTime MandateLastCollectionDate { get; set; }

        [JsonIgnore]
        public bool MandateTrackingIndicator {  get; set; }
        public string? MandateCreditorNameonAccount { get; set; }
        public string? MandateCreditorAccountNo {  get; set; }
        public string? MandateCreditorInstitutionCode {  get; set; }
        public string? MandateDebtorNameonAccount { get; set; }
        public string? MandateDebtorAccountNo { get; set; }
        public string? MandateDebtorInstitutionCode { get; set; }
    }
}
