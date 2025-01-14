using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs.Vouchers;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Vouchers.Queries.GetListVoucherIgnoreQueryFilter
{
    public class GetListVoucherIgnoreQueryFilterQueryResponse : PaginatedResultDto<VoucherDto>
    {
        public GetListVoucherIgnoreQueryFilterQueryResponse(List<VoucherDto> items, long totalCount) : base(items, totalCount)
        {
        }
    }
}