using MediatR;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Wards.Queries.GetWardById
{
    public class GetWardByIdQuery : IRequest<GetWardByIdQueryResponse>
    {
        public Guid Id { get; set; }
        public string includeProperties { get; set; } = "";
    }
}