using MediatR;
using Pizza4Ps.CustomerService.Application.Abstractions;
using static Pizza4Ps.CustomerService.Domain.Enums.VoucherEnum;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Vouchers.Commands.CreateVoucher
{
    public class CreateVoucherCommand : IRequest<ResultDto<Guid>>
    {
        public string Code { get; set; }
        public DiscountTypeEnum DiscountType { get; set; }
        public decimal Value { get; set; }
        public int PointUsed { get; set; }
        public DateTime ExpiryDate { get; set; }
        public VoucherStatusEnum Status { get; set; }
        public Guid CustomerId { get; set; }
    }
}
