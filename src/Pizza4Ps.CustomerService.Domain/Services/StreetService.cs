using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using Pizza4Ps.CustomerService.Domain.Abstractions;
using Pizza4Ps.CustomerService.Domain.Abstractions.Services;
using Pizza4Ps.CustomerService.Domain.Services.ServiceBase;
using Pizza4Ps.CustomerService.Domain.Entities;
using Pizza4Ps.CustomerService.Domain.Constants;
using Pizza4Ps.CustomerService.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Pizza4Ps.CustomerService.Domain.Services
{
    public class StreetService : DomainService, IStreetService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStreetRepository _streetRepository;

        public StreetService(IUnitOfWork unitOfWork, IStreetRepository streetRepository)
        {
            _unitOfWork = unitOfWork;
            _streetRepository = streetRepository;
        }

        public async Task<Guid> CreateAsync(string name, Guid wardId)
        {
            var entity = new Street(Guid.NewGuid(), name, wardId);
            _streetRepository.Add(entity);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
        {
            var entities = await _streetRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                if (IsHardDeleted)
                {
                    _streetRepository.HardDelete(entity);
                }
                else
                {
                    _streetRepository.SoftDelete(entity);
                }
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task RestoreAsync(List<Guid> ids)
        {
            var entities = await _streetRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                _streetRepository.Restore(entity);
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<Guid> UpdateAsync(Guid id, string name, Guid wardId)
        {
            var entity = await _streetRepository.GetSingleByIdAsync(id);
            entity.UpdateStreet(name, wardId);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }
    }
}
