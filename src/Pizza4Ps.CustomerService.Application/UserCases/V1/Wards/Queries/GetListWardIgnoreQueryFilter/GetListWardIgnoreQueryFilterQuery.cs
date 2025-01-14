using MediatR;
using Pizza4Ps.CustomerService.Application.DTOs.Wards;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Wards.Queries.GetListWardIgnoreQueryFilter
{
    public class GetListWardIgnoreQueryFilterQuery : IRequest<GetListWardIgnoreQueryFilterQueryResponse>
    {
        public GetListWardIgnoreQueryFilterDto GetListWardIgnoreQueryFilterDto { get; set; }
    }
}