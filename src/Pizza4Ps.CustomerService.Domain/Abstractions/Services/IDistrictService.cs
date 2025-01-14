using Pizza4Ps.CustomerService.Domain.Abstractions.Services.ServiceBase;

namespace Pizza4Ps.CustomerService.Domain.Abstractions.Services
{
    public interface IDistrictService : IDomainService
    {
        Task<Guid> CreateAsync(string name, Guid provinceId);
        Task<Guid> UpdateAsync(Guid id, string name, Guid provinceId);
        Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
        Task RestoreAsync(List<Guid> ids);
    }
}
