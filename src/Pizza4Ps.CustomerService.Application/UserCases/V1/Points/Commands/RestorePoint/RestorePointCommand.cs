using MediatR;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Points.Commands.RestorePoint
{
    public class RestorePointCommand : IRequest
    {
        public List<Guid> Ids { get; set; }
    }
}
