using MediatR;
using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Domain.Abstractions.Services;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Points.Commands.CreatePoint
{
    public class CreatePointCommandHandler : IRequestHandler<CreatePointCommand, ResultDto<Guid>>
    {
        private readonly IPointService _pointService;

        public CreatePointCommandHandler(IPointService pointService)
        {
            _pointService = pointService;
        }

        public async Task<ResultDto<Guid>> Handle(CreatePointCommand request, CancellationToken cancellationToken)
        {
            var result = await _pointService.CreateAsync(
                request.Score,
                request.ExpiryDate,
                request.CustomerId);
            return new ResultDto<Guid>
            {
                Id = result
            };
        }
    }
}