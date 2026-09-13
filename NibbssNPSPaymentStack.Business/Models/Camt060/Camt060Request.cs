using System.Text.Json.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Camt060
{
    public class Camt060Request
    {
        [JsonIgnore]
        public string? MessageId { get; set; }

        [JsonIgnore]
        public DateTime? CreateAt { get; set; }
        public string? SenderInstitutionCode { get; set; }

        [JsonIgnore]
        public string? ReportingRequestingId { get; set; }
        public string? RequestedMessageNameId { get; set; } //Intraday,statement, balance
        public string? AccountNo { get; set; }
        public string? CurrencyCode { get; set; }
        public string? AcoountOwnerInstitutionCode { get; set; }
        public string? AccountServicerInstitutionCode { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string? ReportPeriodType { get; set; }
        public string? CreditorDesignation { get;set; }
        public string? CreditorIdType { get; set; }
        public string? CreditorIdValue { get; set; }
        public string? CreditorAccountTier { get; set; }
        public string? TransactionLocation { get; set; }
        public int ChannelCode { get; set; }

        [JsonIgnore]
        public bool FixedCollectionAmount { get; set; }
        public string? MandateCode { get; set; }
    }
}
