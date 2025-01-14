using MediatR;
using Pizza4Ps.CustomerService.Application.DTOs.Vouchers;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Vouchers.Commands.UpdateVoucher
{
    public class UpdateVoucherCommand : IRequest<UpdateVoucherCommandResponse>
    {
        public Guid Id { get; set; }
        public UpdateVoucherDto UpdateVoucherDto { get; set; }
    }
}