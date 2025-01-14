using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs.Wards;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Wards.Queries.GetListWardIgnoreQueryFilter
{
    public class GetListWardIgnoreQueryFilterQueryResponse : PaginatedResultDto<WardDto>
    {
        public GetListWardIgnoreQueryFilterQueryResponse(List<WardDto> items, long totalCount) : base(items, totalCount)
        {
        }
    }
}