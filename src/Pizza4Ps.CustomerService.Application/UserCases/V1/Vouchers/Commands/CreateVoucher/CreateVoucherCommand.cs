using MediatR;
using Pizza4Ps.CustomerService.Application.DTOs.Vouchers;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Vouchers.Commands.CreateVoucher
{
    public class CreateVoucherCommand : IRequest<CreateVoucherCommandResponse>
    {
        public CreateVoucherDto CreateVoucherDto { get; set; }
    }
}
