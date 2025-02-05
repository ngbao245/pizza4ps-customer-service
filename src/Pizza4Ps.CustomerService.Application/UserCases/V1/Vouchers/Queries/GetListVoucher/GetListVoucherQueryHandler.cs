using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs;
using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using Pizza4Ps.CustomerService.Domain.Constants;
using Pizza4Ps.CustomerService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Vouchers.Queries.GetListVoucher
{
    public class GetListVoucherQueryHandler : IRequestHandler<GetListVoucherQuery, PaginatedResultDto<VoucherDto>>
    {
        private readonly IMapper _mapper;
        private readonly IVoucherRepository _voucherRepository;

        public GetListVoucherQueryHandler(IMapper mapper, IVoucherRepository voucherRepository)
        {
            _mapper = mapper;
            _voucherRepository = voucherRepository;
        }

        public async Task<PaginatedResultDto<VoucherDto>> Handle(GetListVoucherQuery request, CancellationToken cancellationToken)
        {
            var query = _voucherRepository.GetListAsNoTracking(
                x => (request.Code == null || x.Code.Contains(request.Code))
                && (request.DiscountType == null || x.DiscountType == request.DiscountType)
                && (request.Value == null || x.Value == request.Value)
                && (request.PointUsed == null || x.PointUsed == request.PointUsed)
                && (request.ExpiryDate == null || x.ExpiryDate == request.ExpiryDate)
                && (request.Status == null || x.Status == request.Status)
                && (request.CustomerId == null || x.CustomerId == request.CustomerId),
                includeProperties: request.IncludeProperties);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.VoucherErrorConstant.VOUCHER_NOT_FOUND);
            var result = _mapper.Map<List<VoucherDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<VoucherDto>(result, totalCount);
        }
    }
}