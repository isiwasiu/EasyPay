using NibbssNPSPaymentStack.Business.Models.acmt023;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibbssNPSPaymentStack.Business.Models.Pain009
{
    public class Mndt
    {
        public string? MndtId { get; set; }
        public Ocrncs? Ocrncs { get; set; }
        public bool TrckgInd { get; set; }
        public ColltnAmt? ColltnAmt { get; set; }
        public Party? Cdtr { get; set; }
        public Account? CdtrAcct { get; set; }
        public Agent? CdtrAgt { get; set; }
        public Party? Dbtr { get; set; }
        public Account? DbtrAcct { get; set; }
        public Agent? DbtrAgt { get; set; }
        public RfrdDoc? RfrdDoc { get; set; }
    }
}
