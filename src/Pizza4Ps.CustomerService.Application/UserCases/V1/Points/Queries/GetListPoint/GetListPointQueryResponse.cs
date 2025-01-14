using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs.Points;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Points.Queries.GetListPoint
{
    public class GetListPointQueryResponse : PaginatedResultDto<PointDto>
    {
        public GetListPointQueryResponse(List<PointDto> items, long totalCount) : base(items, totalCount)
        {
        }
    }
}