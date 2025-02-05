using MediatR;
using Pizza4Ps.CustomerService.Domain.Abstractions.Services;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Points.Commands.DeletePoint
{
    public class DeletePointCommandHandler : IRequestHandler<DeletePointCommand>
    {
        private readonly IPointService _pointService;

        public DeletePointCommandHandler(IPointService pointService)
        {
            _pointService = pointService;
        }

        public async Task Handle(DeletePointCommand request, CancellationToken cancellationToken)
        {
            await _pointService.DeleteAsync(request.Ids, request.isHardDelete);
        }
    }
}