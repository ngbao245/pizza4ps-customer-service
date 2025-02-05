using Pizza4Ps.CustomerService.Domain.Abstractions.Services.ServiceBase;

namespace Pizza4Ps.CustomerService.Domain.Abstractions.Services
{
    public interface IPointService : IDomainService
    {
        Task<Guid> CreateAsync(int score, DateTime expiryDate, Guid customerId);
        Task<Guid> UpdateAsync(Guid id, int score, DateTime expiryDate, Guid customerId);
        Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
        Task RestoreAsync(List<Guid> ids);
    }
}
