using MediatR;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Vouchers.Commands.DeleteVoucher
{
    public class DeleteVoucherCommand : IRequest
    {
        public List<Guid> Ids { get; set; }
        public bool isHardDelete { get; set; }
    }
}