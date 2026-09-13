using NibbssNPSPaymentStack.Business.Models.Pacs008;


namespace NibbssNPSPaymentStack.Business.Models.Pain009
{
    public class Pain009CustomData
    {
        public DebtorInfo? DebtorInfo { get; set; }
        public Pain009DebtorMetadata? DebtorMetadata { get; set; }
        public CreditorInfo? CreditorInfo { get; set; }
        public Pain009TransactionInfo? TransactionInfo { get; set; }
    }
}
