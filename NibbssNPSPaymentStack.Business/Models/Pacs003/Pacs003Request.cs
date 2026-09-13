using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NibbssNPSPaymentStack.Business.Models.Pacs003
{
    public class Pacs003Request
    {
        [JsonIgnore]
        public string? MessageId {  get; set; }
        [JsonIgnore]
        public DateTime CreateAt {  get; set; }
        public int NoOfTransaction {  get; set; }
        public decimal ControlSumAmount {  get; set; }
        public string? CreditorInstitutionCode {  get; set; }
        public string? DebtorInstitutionCode { get; set; }

        [JsonIgnore]
        public string? InstructionId {  get; set; }

        [JsonIgnore]
        public string? EndtoEndId { get; set; }

        [JsonIgnore]
        public string? TxtId {  get; set; }

        public decimal SettlementAmount {  get; set; }
        public string? SettlementCurrency {  get; set; }
        public DateTime SettlementDate { get; set; }
        public string? MandateId {  get; set; }
        public DateTime MandateDate {  get; set; }
        public string? FirstCollectionDate {  get; set; }
        public string? FinalCollectionDate { get; set; }
        public string? FrequencyType { get; set; }
        public string? CreditorAccountName {  get; set; }
        public string? CreditorAccountNo {  get; set; }
        public string? DebtorAccountName {  get; set; }
        public string? DebtorAccountNo {  get; set; }
        public string? Narration {  get; set; }
        public string? DebtorAccountDesignation {  get; set; }
        public string? DebtorAccountTier {  get; set; }
        public string? DebtorIdType { get; set; }
        public string? DebtorValue {  get; set; }

        public string? CreditorAccountDesignation { get; set; }
        public string? CreditorAccountTier { get; set; }
        public string? CreditorIdType { get; set; }
        public string? CreditorValue { get; set; }

        [JsonIgnore]
        public string ? TransactionLocation {  get; set; }
        public string? NameEquiryMessageId {  get; set; }
        public string? ChannelCode {  get; set; }
        public string? BiometricData {  get; set; }

        [JsonIgnore]
        public string? RiskRating {  get; set; }

        [JsonIgnore]
        public bool FixedCollectionAmount {  get; set; }

    }
}
