using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace NibbssNPSPaymentStack.Business.Models.Pacs028
{
    public class Pacs028Request
    {
        [JsonIgnore]
        public string? MessageId { get; set; }

        [JsonIgnore]
        public DateTime CreateAt { get; set; }
        public string? SourceInstitutionCode { get; set; }
        public string? Pacs008MessageId { get; set; }
        public DateTime Pacs008CreateAt { get; set; }
        public string? Pacs008TxtId { get; set; }
        public string? DestinationInstitutionCode { get; set; }
        public string? Pacs008SettlementDate {  get; set; }

    }
}
