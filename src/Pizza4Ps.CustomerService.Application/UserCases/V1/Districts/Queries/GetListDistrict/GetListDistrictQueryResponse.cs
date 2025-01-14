using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs.Districts;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Districts.Queries.GetListDistrict
{
    public class GetListDistrictQueryResponse : PaginatedResultDto<DistrictDto>
    {
        public GetListDistrictQueryResponse(List<DistrictDto> items, long totalCount) : base(items, totalCount)
        {
        }
    }
}