using MediatR;
using Pizza4Ps.CustomerService.Application.DTOs.Wards;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Wards.Queries.GetListWard
{
    public class GetListWardQuery : IRequest<GetListWardQueryResponse>
    {
        public GetListWardDto GetListWardDto { get; set; }
    }
}