using MediatR;
using Pizza4Ps.CustomerService.Application.DTOs.Vouchers;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Vouchers.Queries.GetListVoucher
{
    public class GetListVoucherQuery : IRequest<GetListVoucherQueryResponse>
    {
        public GetListVoucherDto GetListVoucherDto { get; set; }
    }
}