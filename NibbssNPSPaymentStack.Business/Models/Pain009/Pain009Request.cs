using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NibbssNPSPaymentStack.Business.Models.Pain009
{
    public class Pain009Request
    {
        [JsonIgnore]
        public string? MessageId { get; set; }  
            
            [JsonIgnore]
        public DateTime CreateAt { get; set; }
        public string? MandateId {  get; set; } 
        public string? SequenceType {  get; set; } //e.g RCUR (recurring) OOFF one off
        public string? FrequencyType {  get; set; } //e.g DAIL, WEEK, MNTH,QURT, YEAR
        public DateTime FirstCollectiondate {  get; set; } //e.g firstDebit
        public DateTime LastCollectiondate { get; set; } //e.g LastDebit

        [JsonIgnore]
        public bool TrackingIndicator {  get; set; }
        public string? Currency {  get; set; }
        public decimal CollectionAmount {  get; set; }
        public string? CreditorNameOnAccount {  get; set; }
        public string? CreditorAccountNo {  get; set; }
        public string? CreditorInstitutionCode {  get; set; }
        public string? DebtororNameOnAccount { get; set; }
        public string? DebtorAccountNo { get; set; }
        public string? DebtorInstitutionCode { get; set; }
        public string? DocumentTypeCode {  get; set; }
        public string? DocumentNumber {  get; set; }
        public string? CreditorAccountDesignation { get; set; }
        public string? CreditorAccountTier {  get; set; }
        public string? CreditorBvn {  get; set; }
        public string? DebtorAccountDesignation { get; set; }
        public string? DebtorAccountTier { get; set; }
        public string? DebtorBvn { get; set; }
        public string? DebtorAddress { get; set; }
        public string? DebtorPhoneNo {  get; set; }
        public string? DebtorEmail {  get; set; }
        public string? TransactionLocation {  get; set; }
        public int ChannelCode {  get; set; }

        [JsonIgnore]
        public string? MandateCategory {  get; set; }

        [JsonIgnore]
        public bool FixedCollectionAmount {  get; set; }
    }
}
