using Dapper;
using NibssNPSPaymentStack.Data.Constant;
using NibssNPSPaymentStack.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibssNPSPaymentStack.Data.Repositories
{
    public class NpsRepositories : INpsRepositories
    {
        private readonly IDappeer _dappeer;
        public NpsRepositories(IDappeer dapper)
        {
            _dappeer = dapper;
        }
        
        public async Task<IEnumerable<GetNameEnquirysDto>> GetNameEnquiries(int pageIndex,int pageSize)
        {
            IEnumerable<GetNameEnquirysDto> Enquiry = Enumerable.Empty<GetNameEnquirysDto>();
            var param = new DynamicParameters();
            param.Add("@PageIndex", pageIndex);
            param.Add("@PageSize", pageSize);

            Enquiry = (IEnumerable<GetNameEnquirysDto>)await _dappeer.GetAllAsync<GetNameEnquirysDto>(DatabaseConstant.sp_GetAccountVerificatons, param);
            

            return Enquiry!;
        }

        public async Task<GetNameEnquiryByMessageIdDto> GetNameEnquiryByMessageId(string messageId)
        {

            GetNameEnquiryByMessageIdDto nameEnquiryDetails = new();
            var param = new DynamicParameters();
            param.Add("MessageId", messageId);
            nameEnquiryDetails = (GetNameEnquiryByMessageIdDto)await _dappeer.GetAsync<GetNameEnquiryByMessageIdDto>(DatabaseConstant.sp_GetAccountVerificatonByMessageId, param);

            return nameEnquiryDetails!;
        }

        public async Task<NameEnquiryResponseDto> InsertNameEnquiry(CreateNameEnquiryDto payload)
        {
            var response = new NameEnquiryResponseDto();
            var param = new DynamicParameters();
            param.Add("@MessageId",payload.MessageId);
            param.Add("@encryptRequest", payload.EncryptedRequest);
            param.Add("@accountNo", payload.AccountNo);

            response = await _dappeer.ExecuteInTransactionAsync<NameEnquiryResponseDto>(DatabaseConstant.sp_SaveAccountVerificaton, param);

            return response!;
        }

        public async Task<NameEnquiryResponseDto> UpdateNameEnquiry(UpdateNameEnquiryDto payload)
        {
            var response = new NameEnquiryResponseDto();
            var param = new DynamicParameters();
            param.Add("@MessageId", payload.MessageId);
            param.Add("@encryptResponse", payload.EncryptedResponse);
            param.Add("@status", payload.Status);
         

            response = await _dappeer.ExecuteInTransactionAsync<NameEnquiryResponseDto>(DatabaseConstant.sp_UpdateAccountVerificaton, param);

            return response!;
        }
    }
}
