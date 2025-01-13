using Pizza4Ps.CustomerService.Domain.Entities;
using static Pizza4Ps.CustomerService.Domain.Enums.VoucherEnum;

namespace Pizza4Ps.CustomerService.Application.DTOs.Vouchers
{
    public class VoucherDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public DiscountTypeEnum DiscountType { get; set; }
        public decimal Value { get; set; }
        public int PointUsed { get; set; }
        public DateTime ExpiryDate { get; set; }
        public VoucherStatusEnum Status { get; set; }
        public Guid CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
