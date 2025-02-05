using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs.Districts;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Districts.Queries.GetListDistrict
{
    public class GetListDistrictQuery : PaginatedQuery<PaginatedResultDto<DistrictDto>>
    {
        public string? Name { get; set; }
        public Guid? ProvinceId { get; set; }
    }
}