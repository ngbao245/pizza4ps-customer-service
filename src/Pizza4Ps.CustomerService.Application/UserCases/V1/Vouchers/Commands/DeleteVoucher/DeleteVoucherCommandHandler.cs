using MediatR;
using Pizza4Ps.CustomerService.Domain.Abstractions.Services;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Vouchers.Commands.DeleteVoucher
{
    public class DeleteVoucherCommandHandler : IRequestHandler<DeleteVoucherCommand>
    {
        private readonly IVoucherService _voucherService;

        public DeleteVoucherCommandHandler(IVoucherService voucherService)
        {
            _voucherService = voucherService;
        }

        public async Task Handle(DeleteVoucherCommand request, CancellationToken cancellationToken)
        {
            await _voucherService.DeleteAsync(request.Ids, request.isHardDelete);
        }
    }
}