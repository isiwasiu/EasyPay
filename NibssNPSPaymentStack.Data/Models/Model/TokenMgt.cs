using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibssNPSPaymentStack.Data.Models.Model
{
    [Table("TokenMgt")]
    public class TokenMgt
    {
        public int Id { get; set; }
        public DateTime creationdatetime { get; set; }
        public string access_token { get; set; } = string.Empty;
        public int expires_in { get; set; }
    }
}
