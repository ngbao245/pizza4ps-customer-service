using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs.Provinces;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Provinces.Queries.GetListProvinceIgnoreQueryFilter
{
    public class GetListProvinceIgnoreQueryFilterQueryResponse : PaginatedResultDto<ProvinceDto>
    {
        public GetListProvinceIgnoreQueryFilterQueryResponse(List<ProvinceDto> items, long totalCount) : base(items, totalCount)
        {
        }
    }
}