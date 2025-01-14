using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs.Streets;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Streets.Queries.GetListStreet
{
    public class GetListStreetQueryResponse : PaginatedResultDto<StreetDto>
    {
        public GetListStreetQueryResponse(List<StreetDto> items, long totalCount) : base(items, totalCount)
        {
        }
    }
}