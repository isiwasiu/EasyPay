using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;



namespace NibbssNPSPaymentStack.Business.Models.Pain013
{
    public class Pain013Request
    {
        [JsonIgnore]
        public string? MessageId { get; set; }

        [JsonIgnore]
        public DateTime CreateAt { get; set; }
        public string? InitiatingPartyName { get; set; }//from nibbs

        [JsonIgnore]
        public string? ClientId { get; set; }  //clientId or OrganisationId

        [JsonIgnore]
        public string? PaymentInformationId { get; set; }

        [JsonIgnore]
        public string? PaymentMethod { get;set; }

        [JsonIgnore]
        public DateTime RequestedExecutionDate {  get; set; }
        public string? DebtorAccountName { get; set; }
        public string? DebtorAccountNo { get;set; }
        public string? DebtorInstitutionCode { get; set; }
        public string? CurrencyCode { get; set; }
        public Decimal Amount { get; set; }

        [JsonIgnore]
        public string? EndtoEndId { get; set; }
        public string? CreditorAccountName { get; set; }
        public string? CreditorAccountNo { get; set; }
        public string? CreditorInstitutionCode { get; set; }
        public string? Narration { get; set; }
        public string? DebtorAccountDesignation { get; set; }
        public string? DebtorIdType { get; set; }
        public string? DebtorIdValue { get;set; }
        public string? DebtorAccountTier { get; set; }
        public string? CreditorAccountDesignation { get;set; }
        public string? CreditorIdType { get; set; }
        public string? CreditorIdValue { get; set; }
        public string? CreditorAccountTier { get; set; }
        public string? TransactionLocation { get; set; }
        public int ChannelCode { get; set; }

        [JsonIgnore]
        public string? MandateCategory { get; set; }
        public string? BiometricData { get; set; }
        public string? Address { get; set; }
        public string? Email {  get; set; }
        public string? Phone { get; set; }
    }
}
