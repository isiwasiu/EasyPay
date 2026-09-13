using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibbssNPSPaymentStack.Business.Models.acmt024
{
    public class Report
    {
        public string? OrgnlId { get; set; }
        public bool Vrfctn { get; set; }
        public Rsn? Rsn {  get; set; }
        public OriginalPartyAndAccount? OrgnlPtyAndAcctId { get; set; }
        public UpdtdPtyAndAcctId? UpdtdPtyAndAcctId { get; set; }
        
    }
}
