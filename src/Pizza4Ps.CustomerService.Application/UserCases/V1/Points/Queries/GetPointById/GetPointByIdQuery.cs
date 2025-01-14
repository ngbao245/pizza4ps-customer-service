using MediatR;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Points.Queries.GetPointById
{
    public class GetPointByIdQuery : IRequest<GetPointByIdQueryResponse>
    {
        public Guid Id { get; set; }
        public string includeProperties { get; set; } = "";
    }
}