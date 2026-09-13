using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NibbssNPSPaymentStack.Business.Models.Pain001
{
    public class Pain001Request
    {
        [JsonIgnore] 
        public string? MessageId { get; set; }
        [JsonIgnore]
        public DateTime CreateAt { get; set; }
        public int TotalTransactions { get; set; }
        public decimal TotalAmount { get; set; }
        public string? InitiatingPartyName { get; set; }
        public string? SchemeCode { get; set; }
        public string? ForwardAgentInstitutionCode { get; set; }
        public PaymentInforRequest? PaymentInforRequest { get; set; }
        public string? CreditorAccountDesignation { get; set; }
        public string? CreditorIdType { get; set; }
        public string? CreditorIdValue { get; set; }
        public string? CreditorAccountier { get; set; }
        public string? TransactionLocation { get; set; }
        public int ChannelCode { get; set; }

        [JsonIgnore]
        public bool FixedCollectionAmount { get; set; }

        [JsonIgnore]
        public string? MandateCategoryCode { get; set; }


    }

    public class PaymentInforRequest
    {
        public string? PaymentInformationId { get; set; }

        [JsonIgnore]
        public string? PaymentMethod { get; set; }

        [JsonIgnore]
        public bool BatchBook { get; set; }

        public int NoOfTransaction { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime RequestExecutionDate { get; set; }
        public string? DebtorAccountName { get; set; }
        public string? DebtorAccountNo { get; set; }
        public string? DebtorInstitutionCode { get; set; }
        public string? ChargeBearerType { get; set; }

        [JsonIgnore]
        public string? EndToEndId { get; set; }
        public string? CurrencyCode { get; set; }
        public decimal IntructedAmount { get; set; }
        public string? CreditorInstitutionCode { get; set; }
        public string? CreditorAccountNo { get; set; }
        public string? CreditorAccountName { get; set; }
        public string? RemittanceInformation {  get; set; }

    }
}
