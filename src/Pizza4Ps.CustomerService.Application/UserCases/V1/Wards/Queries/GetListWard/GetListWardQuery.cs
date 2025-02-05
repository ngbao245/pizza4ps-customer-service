using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Wards.Queries.GetListWard
{
    public class GetListWardQuery : PaginatedQuery<PaginatedResultDto<WardDto>>
    {
        public string Name { get; set; }
        public Guid DistrictId { get; set; }
    }
}