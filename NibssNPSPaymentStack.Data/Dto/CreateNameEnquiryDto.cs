using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibssNPSPaymentStack.Data.Dto
{
    public class CreateNameEnquiryDto
    {
        public string? MessageId {  get; set; }
        public string? AccountNo { get; set; }
        public string? EncryptedRequest { get; set; }
    }
}
