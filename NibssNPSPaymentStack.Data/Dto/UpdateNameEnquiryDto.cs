using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibssNPSPaymentStack.Data.Dto
{
    public class UpdateNameEnquiryDto
    {
        public string? MessageId {  get; set; }
        public string? EncryptedResponse {  get; set; }
        public string? Status { get; set; }
        
    }
}
