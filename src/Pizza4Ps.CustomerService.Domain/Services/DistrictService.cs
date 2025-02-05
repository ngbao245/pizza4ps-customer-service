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
    public class DistrictService : DomainService, IDistrictService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDistrictRepository _districtRepository;

        public DistrictService(IUnitOfWork unitOfWork, IDistrictRepository districtRepository)
        {
            _unitOfWork = unitOfWork;
            _districtRepository = districtRepository;
        }

        public async Task<Guid> CreateAsync(string name, Guid provinceId)
        {
            var entity = new District(Guid.NewGuid(), name, provinceId);
            _districtRepository.Add(entity);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
        {
            var entities = await _districtRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                if (IsHardDeleted)
                {
                    _districtRepository.HardDelete(entity);
                }
                else
                {
                    _districtRepository.SoftDelete(entity);
                }
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task RestoreAsync(List<Guid> ids)
        {
            var entities = await _districtRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                _districtRepository.Restore(entity);
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<Guid> UpdateAsync(Guid id, string name, Guid provinceId)
        {
            var entity = await _districtRepository.GetSingleByIdAsync(id);
            entity.UpdateDistrict(name, provinceId);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }
    }
}
