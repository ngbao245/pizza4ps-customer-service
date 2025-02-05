using MediatR;
using Pizza4Ps.CustomerService.Application.DTOs.Districts;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Districts.Queries.GetDistrictById
{
    public class GetDistrictByIdQuery : IRequest<DistrictDto>
    {
        public Guid Id { get; set; }
        public string IncludeProperties { get; set; } = "";
    }
}