using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibbssNPSPaymentStack.Business.Models.Pain013
{
    public class Pain013GrpHdr
    {
        public string? MsgId { get; set; }
        public DateTime CreDtTm {  get; set; }
        public Pain013InitgPty? InitgPty { get; set; }
    }
}
