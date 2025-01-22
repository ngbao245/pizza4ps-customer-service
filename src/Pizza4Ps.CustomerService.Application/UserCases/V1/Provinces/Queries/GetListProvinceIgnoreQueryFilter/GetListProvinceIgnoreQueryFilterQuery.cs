using MediatR;
using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Provinces.Queries.GetListProvinceIgnoreQueryFilter
{
    public class GetListProvinceIgnoreQueryFilterQuery : PaginatedQuery<PaginatedResultDto<ProvinceDto>>
    {
        public bool IsDeleted { get; set; } = false;
        public string? Name { get; set; }
    }
}