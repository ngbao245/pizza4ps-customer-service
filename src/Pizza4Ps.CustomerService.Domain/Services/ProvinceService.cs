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
    public class ProvinceService : DomainService, IProvinceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProvinceRepository _provinceRepository;

        public ProvinceService(IUnitOfWork unitOfWork, IProvinceRepository provinceRepository)
        {
            _unitOfWork = unitOfWork;
            _provinceRepository = provinceRepository;
        }

        public async Task<Guid> CreateAsync(string name)
        {
            var entity = new Province(Guid.NewGuid(), name);
            _provinceRepository.Add(entity);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
        {
            var entities = await _provinceRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                if (IsHardDeleted)
                {
                    _provinceRepository.HardDelete(entity);
                }
                else
                {
                    _provinceRepository.SoftDelete(entity);
                }
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task RestoreAsync(List<Guid> ids)
        {
            var entities = await _provinceRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                _provinceRepository.Restore(entity);
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<Guid> UpdateAsync(Guid id, string name)
        {
            var entity = await _provinceRepository.GetSingleByIdAsync(id);
            entity.UpdateProvince(name);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }
    }
}
