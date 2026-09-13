using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibbssNPSPaymentStack.Business.Models.acmt023
{
    public class GetAccountDetailsByMessageIdViewModel
    {
        public string? NameEnquiryMessageId { get; set; }
        public DateTime NameEnquiryDate {  get; set; }
        public string? AccountNo {  get; set; }
        public string? AccountName {  get; set; }
        public string? AccountTier { get; set; }
        public string? AccountDesignation {  get; set; }
        public string? BVN {  get; set; }
        public bool IsVerificationSuccessful {  get; set; }
        public string? AccountVerificationDetails {  get; set; }

    }
}
