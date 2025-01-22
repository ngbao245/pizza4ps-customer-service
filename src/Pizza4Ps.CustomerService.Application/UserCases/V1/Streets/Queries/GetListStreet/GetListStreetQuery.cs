using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Streets.Queries.GetListStreet
{
    public class GetListStreetQuery : PaginatedQuery<PaginatedResultDto<StreetDto>>
    {
        public string? Name { get; set; }
        public Guid? WardId { get; set; }
    }
}