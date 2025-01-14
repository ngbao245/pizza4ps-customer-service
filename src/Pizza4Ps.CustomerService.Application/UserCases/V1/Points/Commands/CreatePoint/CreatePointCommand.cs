using MediatR;
using Pizza4Ps.CustomerService.Application.DTOs.Points;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Points.Commands.CreatePoint
{
    public class CreatePointCommand : IRequest<CreatePointCommandResponse>
    {
        public CreatePointDto CreatePointDto { get; set; }
    }
}
