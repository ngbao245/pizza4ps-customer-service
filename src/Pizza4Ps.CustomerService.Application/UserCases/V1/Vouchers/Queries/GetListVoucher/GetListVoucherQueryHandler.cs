using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.CustomerService.Application.DTOs.Vouchers;
using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using Pizza4Ps.CustomerService.Domain.Constants;
using Pizza4Ps.CustomerService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Vouchers.Queries.GetListVoucher
{
    public class GetListVoucherQueryHandler : IRequestHandler<GetListVoucherQuery, GetListVoucherQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVoucherRepository _voucherRepository;

        public GetListVoucherQueryHandler(IMapper mapper, IVoucherRepository voucherRepository)
        {
            _mapper = mapper;
            _voucherRepository = voucherRepository;
        }

        public async Task<GetListVoucherQueryResponse> Handle(GetListVoucherQuery request, CancellationToken cancellationToken)
        {
            var query = _voucherRepository.GetListAsNoTracking(
                x => (request.GetListVoucherDto.Code == null || x.Code.Contains(request.GetListVoucherDto.Code))
                && (request.GetListVoucherDto.DiscountType == null || x.DiscountType == request.GetListVoucherDto.DiscountType)
                && (request.GetListVoucherDto.Value == null || x.Value == request.GetListVoucherDto.Value)
                && (request.GetListVoucherDto.PointUsed == null || x.PointUsed == request.GetListVoucherDto.PointUsed)
                && (request.GetListVoucherDto.ExpiryDate == null || x.ExpiryDate == request.GetListVoucherDto.ExpiryDate)
                && (request.GetListVoucherDto.Status == null || x.Status == request.GetListVoucherDto.Status)
                && (request.GetListVoucherDto.CustomerId == null || x.CustomerId == request.GetListVoucherDto.CustomerId),
                includeProperties: request.GetListVoucherDto.includeProperties);
            var entities = await query
                .OrderBy(request.GetListVoucherDto.SortBy)
                .Skip(request.GetListVoucherDto.SkipCount).Take(request.GetListVoucherDto.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.VoucherErrorConstant.VOUCHER_NOT_FOUND);
            var result = _mapper.Map<List<VoucherDto>>(entities);
            var totalCount = await query.CountAsync();
            return new GetListVoucherQueryResponse(result, totalCount);
        }
    }
}