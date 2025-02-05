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
    public class WardService : DomainService, IWardService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWardRepository _wardRepository;

        public WardService(IUnitOfWork unitOfWork, IWardRepository wardRepository)
        {
            _unitOfWork = unitOfWork;
            _wardRepository = wardRepository;
        }

        public async Task<Guid> CreateAsync(string name, Guid wardId)
        {
            var entity = new Ward(Guid.NewGuid(), name, wardId);
            _wardRepository.Add(entity);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
        {
            var entities = await _wardRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                if (IsHardDeleted)
                {
                    _wardRepository.HardDelete(entity);
                }
                else
                {
                    _wardRepository.SoftDelete(entity);
                }
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task RestoreAsync(List<Guid> ids)
        {
            var entities = await _wardRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                _wardRepository.Restore(entity);
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<Guid> UpdateAsync(Guid id, string name, Guid wardId)
        {
            var entity = await _wardRepository.GetSingleByIdAsync(id);
            entity.UpdateWard(name, wardId);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }
    }
}
