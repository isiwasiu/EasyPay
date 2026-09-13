using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NibbssNPSPaymentStack.Business.Models.pain011
{
    public class pain011Request
    {
        [JsonIgnore]
        public string? MessageId {  get; set; }

        [JsonIgnore]
        public DateTime CreateAt {  get; set; }

        public string? MandateMessageId { get; set; }
        public DateTime MandateDate { get; set; }

        [JsonIgnore]
        public string? MandateNameSpace { get; set; }

        public string? CancellationReasonCode {  get; set; }
        public string? CancellationReasonDescription {  get; set; }

        public string? MandateId { get; set; }
        public string? MandateSequenceType { get; set; }
        public string? MandateFrequencyType { get; set; }
        public DateTime MandateFirstCollectionDate { get; set; }
        public DateTime MandateLastCollectionDate { get; set; }

        [JsonIgnore]
        public bool MandateTrackingIndicator { get; set; }

        public string? MandateCreditorNameonAccount { get; set; }
        public string? MandateCreditorAccountNo { get; set; }
        public string? MandateCreditorInstitutionCode { get; set; }
        public string? MandateDebtorNameonAccount { get; set; }
        public string? MandateDebtorAccountNo { get; set; }
        public string? MandateDebtorInstitutionCode { get; set; }

    }
}
