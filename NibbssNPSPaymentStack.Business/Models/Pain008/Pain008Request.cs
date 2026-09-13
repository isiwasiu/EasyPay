using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NibbssNPSPaymentStack.Business.Models.Pain008
{
    public class Pain008Request
    {
        // Group Header
        [JsonIgnore]
        public string MessageId { get; set; }
        [JsonIgnore]
        public DateTime?  CreationDateTime { get; set; }
        public string NumberOfTransactions { get; set; }
        public string ControlSum { get; set; }
        public string InitiatingPartyName { get; set; }
        public string ForwardingAgentBIC { get; set; }

        // Payment Information
        public string PaymentInformationId { get; set; }
        public string PmtMtd { get; set; }
        public string PmtInfNumberOfTransactions { get; set; }
        public string PmtInfControlSum { get; set; }
        public string ServiceLevelCode { get; set; }
        public string LocalInstrumentCode { get; set; }
        public string SequenceType { get; set; }
        public DateTime?  RequestedCollectionDate { get; set; }

        // Creditor
        public string CreditorName { get; set; }
        public string CreditorAccountNumber { get; set; }
        public string CurrencyCode { get; set; }
        public string CreditorAgentBIC { get; set; }
        public string CreditorAgentMemberId { get; set; }

        // Direct Debit Transaction
        public string InstructionId { get; set; }

        [JsonIgnore]
        public string EndToEndId { get; set; }
        public double InstructedAmount { get; set; }
        public string InstructedAmountCurrency { get; set; }
        public string MandateId { get; set; }
        public DateTime? DateOfSignature { get; set; }
        public DateTime? FirstCollectionDate { get; set; }
        public DateTime? FinalCollectionDate { get; set; }
        public string FrequencyType { get; set; }
        public string DebtorAgentMemberId { get; set; }
        public string DebtorName { get; set; }
        public string DebtorAccountIBAN { get; set; }
        public string OtherAccountIdentifier { get; set; }
        public string DebtorCurrencyCode { get; set; }
        public string RemittanceInformation { get; set; }

        // Supplementary Data
        public string PlaceAndName { get; set; }
        public string AccountDesignation { get; set; }
        public string IdType { get; set; }
        public string IdValue { get; set; }
        public string AccountTier { get; set; }
        public string BiometricData { get; set; }
        public string CreditorAccountDesignation { get; set; }
        public string CreditorIdType { get; set; }
        public string CreditorIdValue { get; set; }
        public string CreditorAccountTier { get; set; }
        public string TransactionLocation { get; set; }
        public string NameEnquiryMsgId { get; set; }
        public string ChannelCode { get; set; }
        public bool FixedCollectionAmount { get; set; }
        public string MandateCode { get; set; }
    }
}
