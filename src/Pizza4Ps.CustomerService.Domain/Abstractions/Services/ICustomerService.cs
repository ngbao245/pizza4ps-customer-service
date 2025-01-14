using Pizza4Ps.CustomerService.Domain.Abstractions.Services.ServiceBase;
using Pizza4Ps.CustomerService.Domain.Enums;

namespace Pizza4Ps.CustomerService.Domain.Abstractions.Services
{
    public interface ICustomerService : IDomainService
    {
        Task<Guid> CreateAsync(string firstName, string lastName, GenderEnum gender, DateTime dateOfBirth, string email, string phoneNumber, string avatar, Guid streetId);
        Task<Guid> UpdateAsync(Guid id, string firstName, string lastName, GenderEnum gender, DateTime dateOfBirth, string email, string phoneNumber, string avatar, Guid streetId);
        Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
        Task RestoreAsync(List<Guid> ids);
    }
}
