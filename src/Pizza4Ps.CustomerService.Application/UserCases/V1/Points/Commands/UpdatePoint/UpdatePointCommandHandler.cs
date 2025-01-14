using MediatR;
using Pizza4Ps.CustomerService.Domain.Abstractions.Services;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Points.Commands.UpdatePoint
{
    public class UpdatePointCommandHandler : IRequestHandler<UpdatePointCommand, UpdatePointCommandResponse>
    {
        private readonly IPointService _pointService;

        public UpdatePointCommandHandler(IPointService pointService)
        {
            _pointService = pointService;
        }

        public async Task<UpdatePointCommandResponse> Handle(UpdatePointCommand request, CancellationToken cancellationToken)
        {
            var result = await _pointService.UpdateAsync(
                request.Id,
                request.UpdatePointDto.Score,
                request.UpdatePointDto.ExpiryDate,
                request.UpdatePointDto.CustomerId);
            return new UpdatePointCommandResponse
            {
                Id = result
            };
        }
    }
}