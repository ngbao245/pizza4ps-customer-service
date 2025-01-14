using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs.Districts;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Districts.Queries.GetListDistrictIgnoreQueryFilter
{
    public class GetListDistrictIgnoreQueryFilterQueryResponse : PaginatedResultDto<DistrictDto>
    {
        public GetListDistrictIgnoreQueryFilterQueryResponse(List<DistrictDto> items, long totalCount) : base(items, totalCount)
        {
        }
    }
}