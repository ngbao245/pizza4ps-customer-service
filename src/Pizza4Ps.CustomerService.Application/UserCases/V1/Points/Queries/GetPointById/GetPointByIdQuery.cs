using MediatR;
using Pizza4Ps.CustomerService.Application.DTOs;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Points.Queries.GetPointById
{
    public class GetPointByIdQuery : IRequest<PointDto>
    {
        public Guid Id { get; set; }
        public string IncludeProperties { get; set; } = "";
    }
}