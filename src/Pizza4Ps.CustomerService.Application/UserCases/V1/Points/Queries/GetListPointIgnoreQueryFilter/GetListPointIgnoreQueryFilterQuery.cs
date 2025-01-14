using MediatR;
using Pizza4Ps.CustomerService.Application.DTOs.Points;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Points.Queries.GetListPointIgnoreQueryFilter
{
    public class GetListPointIgnoreQueryFilterQuery : IRequest<GetListPointIgnoreQueryFilterQueryResponse>
    {
        public GetListPointIgnoreQueryFilterDto GetListPointIgnoreQueryFilterDto { get; set; }
    }
}