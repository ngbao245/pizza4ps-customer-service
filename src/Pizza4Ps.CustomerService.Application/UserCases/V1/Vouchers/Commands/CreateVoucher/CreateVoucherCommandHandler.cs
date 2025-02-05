using MediatR;
using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Domain.Abstractions.Services;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Vouchers.Commands.CreateVoucher
{
    public class CreateVoucherCommandHandler : IRequestHandler<CreateVoucherCommand, ResultDto<Guid>>
    {
        private readonly IVoucherService _voucherService;

        public CreateVoucherCommandHandler(IVoucherService voucherService)
        {
            _voucherService = voucherService;
        }

        public async Task<ResultDto<Guid>> Handle(CreateVoucherCommand request, CancellationToken cancellationToken)
        {
            var result = await _voucherService.CreateAsync(
                request.Code,
                request.DiscountType,
                request.Value,
                request.PointUsed,
                request.ExpiryDate,
                request.Status,
                request.CustomerId);
            return new ResultDto<Guid>
            {
                Id = result
            };
        }
    }
}