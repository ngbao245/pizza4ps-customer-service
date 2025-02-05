using Pizza4Ps.CustomerService.Domain.Abstractions.Services.ServiceBase;
using static Pizza4Ps.CustomerService.Domain.Enums.VoucherEnum;

namespace Pizza4Ps.CustomerService.Domain.Abstractions.Services
{
    public interface IVoucherService : IDomainService
    {
        Task<Guid> CreateAsync(string code, DiscountTypeEnum discountType, decimal value, int pointUsed, DateTime expiryDate, VoucherStatusEnum status, Guid customerId);
        Task<Guid> UpdateAsync(Guid id, string code, DiscountTypeEnum discountType, decimal value, int pointUsed, DateTime expiryDate, VoucherStatusEnum status, Guid customerId);
        Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
        Task RestoreAsync(List<Guid> ids);
    }
}
