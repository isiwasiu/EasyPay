
using System.Text.Json.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pacs008
{
    public class CreditTransferRequest
    {
        [JsonIgnore]
        public string? MssgId { get; set; }

        [JsonIgnore]
        public DateTime CreatedAt { get; set; }

        [JsonIgnore]
        public bool BtchBookg { get; set; }

        [JsonIgnore]
        public int NbOfTxs { get; set; }

        [JsonIgnore]
        public string? SttlmMtd { get; set; }
        public string? SenderInstitutionCode { get; set; }
        public string? ReceivingInstitutionCode { get; set; }

        [JsonIgnore]
        public string? InstrId { get; set; }

        [JsonIgnore]
        public string? EndToEndId { get; set; }

        [JsonIgnore]
        public string? TxId { get; set; }

        [JsonIgnore]
        public string? ClearingChannel { get; set; }

        [JsonIgnore]
        public string? ServiceLevel { get; set; }

        [JsonIgnore]
        public string? LocalInstrument { get; set; }

        [JsonIgnore]
        public string? CategoryPurpose { get; set; }
        public string? CurrencyCode { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }

        [JsonIgnore]
        public string? ChargeBearer { get; set; }
        public string? SenderName { get; set; }
        public string? SenderAccountNo { get; set; }
        public string? SenderAccountName { get; set; }
        public string? SenderBank {  get; set; }
        public string? BeneficiaryName {  get; set; }
        public string? BeneficiaryAccountNo { get; set; }
        public string? BeneficiaryAccountName {  get; set; }
        public string? BeneficiaryBank {  get; set; }
        public string? Narration {  get; set; }
        public string? DebitorAccountDesignation {  get; set; }
        public string? DebtorIDType {  get; set; }//bvn,nin
        public string? DebtorIDValue {  get; set; }// your bvn or nin
        public string? DebtorAccountTier {  get; set; }
        public string? CreditorAccountDesignation { get; set; }
        public string? CreditorIDType { get; set; }//bvn,nin
        public string? CreditorIDValue { get; set; }// your bvn or nin
        public string? CreditorAccountTier { get; set; }
        public string? TransactionLocation {  get; set; }
        public string? NameEnquiryMssgId {  get; set; }
        public int channelCode {  get; set; }
    }
}
