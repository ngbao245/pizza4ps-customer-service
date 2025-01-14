using MediatR;
using Pizza4Ps.CustomerService.Domain.Abstractions.Services;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Vouchers.Commands.CreateVoucher
{
    public class CreateVoucherCommandHandler : IRequestHandler<CreateVoucherCommand, CreateVoucherCommandResponse>
    {
        private readonly IVoucherService _voucherService;

        public CreateVoucherCommandHandler(IVoucherService voucherService)
        {
            _voucherService = voucherService;
        }

        public async Task<CreateVoucherCommandResponse> Handle(CreateVoucherCommand request, CancellationToken cancellationToken)
        {
            var result = await _voucherService.CreateAsync(
                request.CreateVoucherDto.Code,
                request.CreateVoucherDto.DiscountType,
                request.CreateVoucherDto.Value,
                request.CreateVoucherDto.PointUsed,
                request.CreateVoucherDto.ExpiryDate,
                request.CreateVoucherDto.Status,
                request.CreateVoucherDto.CustomerId);
            return new CreateVoucherCommandResponse
            {
                Id = result
            };
        }
    }
}