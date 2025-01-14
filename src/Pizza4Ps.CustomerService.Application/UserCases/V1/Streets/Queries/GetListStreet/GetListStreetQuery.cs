using MediatR;
using Pizza4Ps.CustomerService.Application.DTOs.Streets;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Streets.Queries.GetListStreet
{
    public class GetListStreetQuery : IRequest<GetListStreetQueryResponse>
    {
        public GetListStreetDto GetListStreetDto { get; set; }
    }
}