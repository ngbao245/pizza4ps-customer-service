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
    public class PointService : DomainService, IPointService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPointRepository _pointRepository;

        public PointService(IUnitOfWork unitOfWork, IPointRepository pointRepository)
        {
            _unitOfWork = unitOfWork;
            _pointRepository = pointRepository;
        }

        public async Task<Guid> CreateAsync(int score, DateTime expiryDate, Guid customerId)
        {
            var entity = new Point(Guid.NewGuid(), score, expiryDate, customerId);
            _pointRepository.Add(entity);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
        {
            var entities = await _pointRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                if (IsHardDeleted)
                {
                    _pointRepository.HardDelete(entity);
                }
                else
                {
                    _pointRepository.SoftDelete(entity);
                }
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task RestoreAsync(List<Guid> ids)
        {
            var entities = await _pointRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                _pointRepository.Restore(entity);
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<Guid> UpdateAsync(Guid id, int score, DateTime expiryDate, Guid customerId)
        {
            var entity = await _pointRepository.GetSingleByIdAsync(id);
            entity.UpdatePoint(score, expiryDate, customerId);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }
    }
}
