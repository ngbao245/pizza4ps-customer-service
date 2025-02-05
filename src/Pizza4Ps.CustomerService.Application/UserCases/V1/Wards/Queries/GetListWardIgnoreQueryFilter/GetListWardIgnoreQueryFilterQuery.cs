using MediatR;
using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Wards.Queries.GetListWardIgnoreQueryFilter
{
    public class GetListWardIgnoreQueryFilterQuery : PaginatedQuery<PaginatedResultDto<WardDto>>
    {
        public bool IsDeleted { get; set; } = false;
        public string Name { get; set; }
        public Guid DistrictId { get; set; }
    }
}