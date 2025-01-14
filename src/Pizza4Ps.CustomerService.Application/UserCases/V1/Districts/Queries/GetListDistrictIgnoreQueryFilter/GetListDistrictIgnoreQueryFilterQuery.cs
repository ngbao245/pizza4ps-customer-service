using MediatR;
using Pizza4Ps.CustomerService.Application.DTOs.Districts;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Districts.Queries.GetListDistrictIgnoreQueryFilter
{
    public class GetListDistrictIgnoreQueryFilterQuery : IRequest<GetListDistrictIgnoreQueryFilterQueryResponse>
    {
        public GetListDistrictIgnoreQueryFilterDto GetListDistrictIgnoreQueryFilterDto { get; set; }
    }
}