using NibbssNPSPaymentStack.Business.Models.acmt023;
using NibbssNPSPaymentStack.Business.Models.Pacs008;


namespace NibbssNPSPaymentStack.Business.Models.acmt024
{
    public class IdVrfctnRpt
    {
        public Acmt024Assignment? Assgnmt { get; set; }
        public OriginalAssignment? OrgnlAssgnmt { get; set; }
        public Report? Rpt { get; set; }
        public Acmt024SupplementaryData? SplmtryData { get; set; }
    }
}
