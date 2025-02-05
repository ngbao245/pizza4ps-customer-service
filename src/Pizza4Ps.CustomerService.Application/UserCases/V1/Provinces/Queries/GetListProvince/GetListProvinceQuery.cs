using MediatR;
using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Provinces.Queries.GetListProvince
{
    public class GetListProvinceQuery : PaginatedQuery<PaginatedResultDto<ProvinceDto>>
    {
        public string? Name { get; set; }
    }
}