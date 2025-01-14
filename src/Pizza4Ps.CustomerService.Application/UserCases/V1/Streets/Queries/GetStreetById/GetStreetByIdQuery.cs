using MediatR;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Streets.Queries.GetStreetById
{
    public class GetStreetByIdQuery : IRequest<GetStreetByIdQueryResponse>
    {
        public Guid Id { get; set; }
        public string includeProperties { get; set; } = "";
    }
}