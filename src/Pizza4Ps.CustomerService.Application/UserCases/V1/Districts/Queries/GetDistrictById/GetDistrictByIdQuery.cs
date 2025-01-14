using MediatR;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Districts.Queries.GetDistrictById
{
    public class GetDistrictByIdQuery : IRequest<GetDistrictByIdQueryResponse>
    {
        public Guid Id { get; set; }
        public string includeProperties { get; set; } = "";
    }
}