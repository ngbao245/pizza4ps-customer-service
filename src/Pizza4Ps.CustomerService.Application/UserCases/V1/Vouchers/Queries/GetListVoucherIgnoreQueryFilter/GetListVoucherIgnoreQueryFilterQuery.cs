using MediatR;
using Pizza4Ps.CustomerService.Application.DTOs.Vouchers;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Vouchers.Queries.GetListVoucherIgnoreQueryFilter
{
    public class GetListVoucherIgnoreQueryFilterQuery : IRequest<GetListVoucherIgnoreQueryFilterQueryResponse>
    {
        public GetListVoucherIgnoreQueryFilterDto GetListVoucherIgnoreQueryFilterDto { get; set; }
    }
}