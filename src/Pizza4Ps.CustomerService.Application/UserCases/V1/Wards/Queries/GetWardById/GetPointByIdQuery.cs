using MediatR;
using Pizza4Ps.CustomerService.Application.DTOs;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Wards.Queries.GetWardById
{
    public class GetWardByIdQuery : IRequest<WardDto>
    {
        public Guid Id { get; set; }
        public string IncludeProperties { get; set; } = "";
    }
}