using MediatR;
using Pizza4Ps.CustomerService.Domain.Abstractions.Services;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Points.Commands.CreatePoint
{
    public class CreatePointCommandHandler : IRequestHandler<CreatePointCommand, CreatePointCommandResponse>
    {
        private readonly IPointService _pointService;

        public CreatePointCommandHandler(IPointService pointService)
        {
            _pointService = pointService;
        }

        public async Task<CreatePointCommandResponse> Handle(CreatePointCommand request, CancellationToken cancellationToken)
        {
            var result = await _pointService.CreateAsync(
                request.CreatePointDto.Score,
                request.CreatePointDto.ExpiryDate,
                request.CreatePointDto.CustomerId);
            return new CreatePointCommandResponse
            {
                Id = result
            };
        }
    }
}