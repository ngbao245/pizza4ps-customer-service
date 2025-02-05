using MediatR;
using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Streets.Queries.GetListStreetIgnoreQueryFilter
{
    public class GetListStreetIgnoreQueryFilterQuery : PaginatedQuery<PaginatedResultDto<StreetDto>>
    {
        public bool IsDeleted { get; set; } = false;
        public string? Name { get; set; }
        public Guid? WardId { get; set; }
    }
}