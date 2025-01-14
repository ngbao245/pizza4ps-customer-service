using MediatR;
using Pizza4Ps.CustomerService.Application.DTOs.Points;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Points.Commands.UpdatePoint
{
    public class UpdatePointCommand : IRequest<UpdatePointCommandResponse>
    {
        public Guid Id { get; set; }
        public UpdatePointDto UpdatePointDto { get; set; }
    }
}