using MediatR;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Points.Commands.DeletePoint
{
    public class DeletePointCommand : IRequest
    {
        public List<Guid> Ids { get; set; }
        public bool isHardDelete { get; set; }
    }
}