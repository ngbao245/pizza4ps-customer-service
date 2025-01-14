using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using Pizza4Ps.CustomerService.Domain.Abstractions;
using Pizza4Ps.CustomerService.Domain.Abstractions.Services;
using Pizza4Ps.CustomerService.Domain.Enums;
using Pizza4Ps.CustomerService.Domain.Services.ServiceBase;
using Pizza4Ps.CustomerService.Domain.Entities;
using System.Xml.Linq;
using Pizza4Ps.CustomerService.Domain.Constants;
using Pizza4Ps.CustomerService.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Pizza4Ps.CustomerService.Domain.Services
{
    public class VoucherService : DomainService, IVoucherService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVoucherRepository _voucherRepository;

        public VoucherService(IUnitOfWork unitOfWork, IVoucherRepository voucherRepository)
        {
            _unitOfWork = unitOfWork;
            _voucherRepository = voucherRepository;
        }

        public async Task<Guid> CreateAsync(string code, VoucherEnum.DiscountTypeEnum discountType, decimal value, int pointUsed, DateTime expiryDate, VoucherEnum.VoucherStatusEnum status, Guid customerId)
        {
            var entity = new Voucher(Guid.NewGuid(), code, discountType, value, pointUsed, expiryDate, status, customerId);
            _voucherRepository.Add(entity);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
        {
            var entities = await _voucherRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                if (IsHardDeleted)
                {
                    _voucherRepository.HardDelete(entity);
                }
                else
                {
                    _voucherRepository.SoftDelete(entity);
                }
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task RestoreAsync(List<Guid> ids)
        {
            var entities = await _voucherRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                _voucherRepository.Restore(entity);
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<Guid> UpdateAsync(Guid id, string code, VoucherEnum.DiscountTypeEnum discountType, decimal value, int pointUsed, DateTime expiryDate, VoucherEnum.VoucherStatusEnum status, Guid customerId)
        {
            var entity = await _voucherRepository.GetSingleByIdAsync(id);
            entity.UpdateVoucher(code, discountType, value, pointUsed, expiryDate, status, customerId);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }
    }
}
