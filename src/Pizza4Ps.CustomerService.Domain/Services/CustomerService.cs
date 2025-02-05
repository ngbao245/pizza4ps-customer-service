using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using Pizza4Ps.CustomerService.Domain.Abstractions;
using Pizza4Ps.CustomerService.Domain.Abstractions.Services;
using Pizza4Ps.CustomerService.Domain.Enums;
using Pizza4Ps.CustomerService.Domain.Services.ServiceBase;
using Pizza4Ps.CustomerService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.CustomerService.Domain.Constants;
using Pizza4Ps.CustomerService.Domain.Exceptions;

namespace Pizza4Ps.CustomerService.Domain.Services
{
    public class CustomerService : DomainService, ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
        {
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
        }

        public async Task<Guid> CreateAsync(string firstName, string lastName, GenderEnum gender, DateTime dateOfBirth, string email, string phoneNumber, string avatar, Guid streetId)
        {
            var entity = new Customer(Guid.NewGuid(), firstName, lastName, gender, dateOfBirth, email, phoneNumber, avatar, streetId);
            _customerRepository.Add(entity);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
        {
            var entities = await _customerRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                if (IsHardDeleted)
                {
                    _customerRepository.HardDelete(entity);
                }
                else
                {
                    _customerRepository.SoftDelete(entity);
                }
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task RestoreAsync(List<Guid> ids)
        {
            var entities = await _customerRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                _customerRepository.Restore(entity);
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<Guid> UpdateAsync(Guid id, string firstName, string lastName, GenderEnum gender, DateTime dateOfBirth, string email, string phoneNumber, string avatar, Guid streetId)
        {
            var entity = await _customerRepository.GetSingleByIdAsync(id);
            entity.UpdateCustomer(firstName, lastName, gender, dateOfBirth, email, phoneNumber, avatar, streetId);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }
    }
}
