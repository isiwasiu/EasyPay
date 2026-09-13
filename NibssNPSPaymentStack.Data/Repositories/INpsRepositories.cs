using NibssNPSPaymentStack.Data.Dto;


namespace NibssNPSPaymentStack.Data.Repositories
{
    public interface INpsRepositories
    {
        Task<NameEnquiryResponseDto> InsertNameEnquiry(CreateNameEnquiryDto payload);
        Task<NameEnquiryResponseDto> UpdateNameEnquiry(UpdateNameEnquiryDto payload);
        Task<GetNameEnquiryByMessageIdDto> GetNameEnquiryByMessageId(string messageId);
        Task<IEnumerable<GetNameEnquirysDto>> GetNameEnquiries(int pageIndex, int pageSize);
    }
}
