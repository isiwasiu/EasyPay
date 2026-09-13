namespace NibssNPSPaymentStack.Data.Dto
{
    public class GetNameEnquirysDto
    {
        public long Id { get; set; }
        public string? MessageId {  get; set; }
        public string ? AccountNo {  get; set; }
        public string? Status {  get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdate { get; set; }

    }
}
