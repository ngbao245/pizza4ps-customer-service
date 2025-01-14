using MediatR;
using Pizza4Ps.CustomerService.Application.DTOs.Streets;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Streets.Queries.GetListStreetIgnoreQueryFilter
{
    public class GetListStreetIgnoreQueryFilterQuery : IRequest<GetListStreetIgnoreQueryFilterQueryResponse>
    {
        public GetListStreetIgnoreQueryFilterDto GetListStreetIgnoreQueryFilterDto { get; set; }
    }
}