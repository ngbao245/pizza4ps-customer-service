using Pizza4Ps.CustomerService.Domain.Abstractions.Services.ServiceBase;

namespace Pizza4Ps.CustomerService.Domain.Abstractions.Services
{
    public interface IProvinceService : IDomainService
    {
        Task<Guid> CreateAsync(string name);
        Task<Guid> UpdateAsync(Guid id, string name);
        Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
        Task RestoreAsync(List<Guid> ids);
    }
}
