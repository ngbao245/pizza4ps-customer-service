using Pizza4Ps.CustomerService.Domain.Abstractions.Services.ServiceBase;

namespace Pizza4Ps.CustomerService.Domain.Abstractions.Services
{
    public interface IStreetService : IDomainService
    {
        Task<Guid> CreateAsync(string name, Guid wardId);
        Task<Guid> UpdateAsync(Guid id, string name, Guid wardId);
        Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
        Task RestoreAsync(List<Guid> ids);
    }
}
