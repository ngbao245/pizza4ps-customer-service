using MediatR;
using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs.Districts;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Districts.Queries.GetListDistrictIgnoreQueryFilter
{
    public class GetListDistrictIgnoreQueryFilterQuery : PaginatedQuery<PaginatedResultDto<DistrictDto>>
    {
        public bool IsDeleted { get; set; } = false;
        public string? Name { get; set; }
        public Guid? ProvinceId { get; set; }
    }
}