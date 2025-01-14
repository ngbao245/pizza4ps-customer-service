using Pizza4Ps.CustomerService.Domain.Abstractions.Services.ServiceBase;

namespace Pizza4Ps.CustomerService.Domain.Abstractions.Services
{
    public interface IWardService : IDomainService
    {
        Task<Guid> CreateAsync(string name, Guid districtId);
        Task<Guid> UpdateAsync(Guid id, string name, Guid districtId);
        Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
        Task RestoreAsync(List<Guid> ids);
    }
}
