using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs.Provinces;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Provinces.Queries.GetListProvince
{
    public class GetListProvinceQueryResponse : PaginatedResultDto<ProvinceDto>
    {
        public GetListProvinceQueryResponse(List<ProvinceDto> items, long totalCount) : base(items, totalCount)
        {
        }
    }
}