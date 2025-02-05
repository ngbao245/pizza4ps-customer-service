using MediatR;
using Pizza4Ps.CustomerService.Application.DTOs;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Streets.Queries.GetStreetById
{
    public class GetStreetByIdQuery : IRequest<StreetDto>
    {
        public Guid Id { get; set; }
        public string IncludeProperties { get; set; } = "";
    }
}