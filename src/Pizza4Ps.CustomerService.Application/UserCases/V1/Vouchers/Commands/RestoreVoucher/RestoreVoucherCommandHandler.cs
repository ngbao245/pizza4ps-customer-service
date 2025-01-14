using MediatR;
using Pizza4Ps.CustomerService.Domain.Abstractions.Services;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Vouchers.Commands.RestoreVoucher
{
    public class RestoreVoucherCommandHandler : IRequestHandler<RestoreVoucherCommand>
    {
        private readonly IVoucherService _voucherService;

        public RestoreVoucherCommandHandler(IVoucherService voucherService)
        {
            _voucherService = voucherService;
        }

        public async Task Handle(RestoreVoucherCommand request, CancellationToken cancellationToken)
        {
            await _voucherService.RestoreAsync(request.Ids);
        }
    }
}