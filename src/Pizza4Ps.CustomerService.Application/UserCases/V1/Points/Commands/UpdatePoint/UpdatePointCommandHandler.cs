using MediatR;
using Pizza4Ps.CustomerService.Domain.Abstractions.Services;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Points.Commands.UpdatePoint
{
    public class UpdatePointCommandHandler : IRequestHandler<UpdatePointCommand>
    {
        private readonly IPointService _pointService;

        public UpdatePointCommandHandler(IPointService pointService)
        {
            _pointService = pointService;
        }

        public async Task Handle(UpdatePointCommand request, CancellationToken cancellationToken)
        {
            var result = await _pointService.UpdateAsync(
                request.Id!.Value,
                request.Score,
                request.ExpiryDate,
                request.CustomerId);
        }
    }
}