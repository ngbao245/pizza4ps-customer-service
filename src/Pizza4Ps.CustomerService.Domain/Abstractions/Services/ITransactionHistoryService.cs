using Pizza4Ps.CustomerService.Domain.Abstractions.Services.ServiceBase;

namespace Pizza4Ps.CustomerService.Domain.Abstractions.Services
{
    public interface ITransactionHistoryService : IDomainService
    {
        Task<Guid> CreateAsync(DateTime transactionDate, decimal total, Guid transactionId, Guid customerId);
        Task<Guid> UpdateAsync(Guid id, DateTime transactionDate, decimal total, Guid transactionId, Guid customerId);
        Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
        Task RestoreAsync(List<Guid> ids);
    }
}
