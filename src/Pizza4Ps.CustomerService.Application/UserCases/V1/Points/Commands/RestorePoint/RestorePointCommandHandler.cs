using MediatR;
using Pizza4Ps.CustomerService.Domain.Abstractions.Services;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Points.Commands.RestorePoint
{
    public class RestorePointCommandHandler : IRequestHandler<RestorePointCommand>
    {
        private readonly IPointService _pointService;

        public RestorePointCommandHandler(IPointService pointService)
        {
            _pointService = pointService;
        }

        public async Task Handle(RestorePointCommand request, CancellationToken cancellationToken)
        {
            await _pointService.RestoreAsync(request.Ids);
        }
    }
}