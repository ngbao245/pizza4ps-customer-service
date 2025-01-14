using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs.Streets;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Streets.Queries.GetListStreetIgnoreQueryFilter
{
    public class GetListStreetIgnoreQueryFilterQueryResponse : PaginatedResultDto<StreetDto>
    {
        public GetListStreetIgnoreQueryFilterQueryResponse(List<StreetDto> items, long totalCount) : base(items, totalCount)
        {
        }
    }
}