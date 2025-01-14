using MediatR;
using Pizza4Ps.CustomerService.Application.DTOs.Points;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Points.Queries.GetListPoint
{
    public class GetListPointQuery : IRequest<GetListPointQueryResponse>
    {
        public GetListPointDto GetListPointDto { get; set; }
    }
}