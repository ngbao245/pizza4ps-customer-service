using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs.Wards;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Wards.Queries.GetListWard
{
    public class GetListWardQueryResponse : PaginatedResultDto<WardDto>
    {
        public GetListWardQueryResponse(List<WardDto> items, long totalCount) : base(items, totalCount)
        {
        }
    }
}