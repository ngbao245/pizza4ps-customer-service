using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs.Vouchers;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Vouchers.Queries.GetListVoucher
{
    public class GetListVoucherQueryResponse : PaginatedResultDto<VoucherDto>
    {
        public GetListVoucherQueryResponse(List<VoucherDto> items, long totalCount) : base(items, totalCount)
        {
        }
    }
}