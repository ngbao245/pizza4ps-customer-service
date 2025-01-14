using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.CustomerService.Application.DTOs.Vouchers;
using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Vouchers.Queries.GetListVoucherIgnoreQueryFilter
{
    public class GetListVoucherIgnoreQueryFilterQueryHandler : IRequestHandler<GetListVoucherIgnoreQueryFilterQuery, GetListVoucherIgnoreQueryFilterQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVoucherRepository _voucherRepository;

        public GetListVoucherIgnoreQueryFilterQueryHandler(IMapper mapper, IVoucherRepository voucherRepository)
        {
            _mapper = mapper;
            _voucherRepository = voucherRepository;
        }

        public async Task<GetListVoucherIgnoreQueryFilterQueryResponse> Handle(GetListVoucherIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
        {
            var query = _voucherRepository.GetListAsNoTracking(includeProperties: request.GetListVoucherIgnoreQueryFilterDto.includeProperties).IgnoreQueryFilters()
                .Where(
                    x => (request.GetListVoucherIgnoreQueryFilterDto.Code == null || x.Code.Contains(request.GetListVoucherIgnoreQueryFilterDto.Code))
                    && (request.GetListVoucherIgnoreQueryFilterDto.DiscountType == null || x.DiscountType == request.GetListVoucherIgnoreQueryFilterDto.DiscountType)
                    && (request.GetListVoucherIgnoreQueryFilterDto.Value == null || x.Value == request.GetListVoucherIgnoreQueryFilterDto.Value)
                    && (request.GetListVoucherIgnoreQueryFilterDto.PointUsed == null || x.PointUsed == request.GetListVoucherIgnoreQueryFilterDto.PointUsed)
                    && (request.GetListVoucherIgnoreQueryFilterDto.ExpiryDate == null || x.ExpiryDate == request.GetListVoucherIgnoreQueryFilterDto.ExpiryDate)
                    && (request.GetListVoucherIgnoreQueryFilterDto.Status == null || x.Status == request.GetListVoucherIgnoreQueryFilterDto.Status)
                    && (request.GetListVoucherIgnoreQueryFilterDto.CustomerId == null || x.CustomerId == request.GetListVoucherIgnoreQueryFilterDto.CustomerId)
                    && x.IsDeleted == request.GetListVoucherIgnoreQueryFilterDto.IsDeleted);
            var entities = await query
                .OrderBy(request.GetListVoucherIgnoreQueryFilterDto.SortBy)
                .Skip(request.GetListVoucherIgnoreQueryFilterDto.SkipCount).Take(request.GetListVoucherIgnoreQueryFilterDto.TakeCount).ToListAsync();
            var result = _mapper.Map<List<VoucherDto>>(entities);
            var totalCount = await query.CountAsync();
            return new GetListVoucherIgnoreQueryFilterQueryResponse(result, totalCount);
        }
    }
}