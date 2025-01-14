using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using Pizza4Ps.CustomerService.Domain.Abstractions;
using Pizza4Ps.CustomerService.Domain.Abstractions.Services;
using Pizza4Ps.CustomerService.Domain.Entities;
using Pizza4Ps.CustomerService.Domain.Services.ServiceBase;
using Pizza4Ps.CustomerService.Domain.Constants;
using Pizza4Ps.CustomerService.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Pizza4Ps.CustomerService.Domain.Services
{
    public class TransactionHistoryService : DomainService, ITransactionHistoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITransactionHistoryRepository _transactionHistoryRepository;

        public TransactionHistoryService(IUnitOfWork unitOfWork, ITransactionHistoryRepository transactionHistoryRepository)
        {
            _unitOfWork = unitOfWork;
            _transactionHistoryRepository = transactionHistoryRepository;
        }

        public async Task<Guid> CreateAsync(DateTime transactionDate, decimal total, Guid transactionId, Guid customerId)
        {
            var entity = new TransactionHistory(Guid.NewGuid(), transactionDate, total, transactionId, customerId);
            _transactionHistoryRepository.Add(entity);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
        {
            var entities = await _transactionHistoryRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                if (IsHardDeleted)
                {
                    _transactionHistoryRepository.HardDelete(entity);
                }
                else
                {
                    _transactionHistoryRepository.SoftDelete(entity);
                }
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task RestoreAsync(List<Guid> ids)
        {
            var entities = await _transactionHistoryRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                _transactionHistoryRepository.Restore(entity);
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<Guid> UpdateAsync(Guid id, DateTime transactionDate, decimal total, Guid transactionId, Guid customerId)
        {
            var entity = await _transactionHistoryRepository.GetSingleByIdAsync(id);
            entity.UpdateTransactionHistory(transactionDate, total, transactionId, customerId);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }
    }
}
