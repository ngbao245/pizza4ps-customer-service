namespace Pizza4Ps.CustomerService.Domain.Enums
{
    public class VoucherEnum
    {
        public enum DiscountTypeEnum
        {
            Direct,
            Percentage
        }

        public enum VoucherStatusEnum
        {
            Used,
            NotUsed,
            Expired,
            Inactive
        }
    }
}
