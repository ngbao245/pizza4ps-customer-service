using Pizza4Ps.CustomerService.Domain.Abstractions;
using static Pizza4Ps.CustomerService.Domain.Enums.VoucherEnum;

namespace Pizza4Ps.CustomerService.Domain.Entities
{
    public class Voucher : EntityAuditBase<Guid>
    {
        public string Code { get; set; }
        public DiscountTypeEnum DiscountType { get; set; }
        public decimal Value { get; set; }
        public int PointUsed { get; set; }
        public DateTime ExpiryDate { get; set; }
        public VoucherStatusEnum Status { get; set; }
        public Guid CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public Voucher()
        {
        }

        public Voucher(Guid id, string code, DiscountTypeEnum discountType, decimal value, int pointUsed, DateTime expiryDate, VoucherStatusEnum status, Guid customerId)
        {
            Id = id;
            Code = code;
            DiscountType = discountType;
            Value = value;
            PointUsed = pointUsed;
            ExpiryDate = expiryDate;
            Status = status;
            CustomerId = customerId;
        }

        public void UpdateVoucher(string code, DiscountTypeEnum discountType, decimal value, int pointUsed, DateTime expiryDate, VoucherStatusEnum status, Guid customerId)
        {
            Code = code;
            DiscountType = discountType;
            Value = value;
            PointUsed = pointUsed;
            ExpiryDate = expiryDate;
            Status = status;
            CustomerId = customerId;
        }
    }
}
