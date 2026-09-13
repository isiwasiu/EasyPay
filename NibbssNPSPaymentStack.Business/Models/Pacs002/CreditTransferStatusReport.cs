using System.Text.Json.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pacs002
{
    using System.Text.Json.Serialization;

    namespace NibbssNPSPaymentStack.Business.Models.Pacs002
    {
        public class CreditTransferStatusReport
        {
            [JsonIgnore]
            public string? MssgId { get; set; }

            [JsonIgnore]
            public DateTime CreateAt { get; set; }

            public string? SenderInstitutionCode { get; set; }
            public string? ReceivingInstitutionCode { get; set; }
            public string? CreditTransferMssgId { get; set; }
            public DateTime CreditTransferDate { get; set; }

            [JsonIgnore]
            public bool InvalidAccount { get; set; }

            [JsonIgnore]
            public string? IntrId { get; set; }

            [JsonIgnore]
            public string? EndToEndId { get; set; }

            [JsonIgnore]
            public string? TxtId { get; set; }

        }
    }

}