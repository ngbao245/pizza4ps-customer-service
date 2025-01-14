using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs.Points;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Points.Queries.GetListPointIgnoreQueryFilter
{
    public class GetListPointIgnoreQueryFilterQueryResponse : PaginatedResultDto<PointDto>
    {
        public GetListPointIgnoreQueryFilterQueryResponse(List<PointDto> items, long totalCount) : base(items, totalCount)
        {
        }
    }
}