using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs;
using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.TransactionHistories.Queries.GetListTransactionHistoryIgnoreQueryFilter
{
    public class GetListTransactionHistoryIgnoreQueryFilterQueryHandler : IRequestHandler<GetListTransactionHistoryIgnoreQueryFilterQuery, PaginatedResultDto<TransactionHistoryDto>>
    {
        private readonly IMapper _mapper;
        private readonly ITransactionHistoryRepository _transactionhistoryRepository;

        public GetListTransactionHistoryIgnoreQueryFilterQueryHandler(IMapper mapper, ITransactionHistoryRepository transactionhistoryRepository)
        {
            _mapper = mapper;
            _transactionhistoryRepository = transactionhistoryRepository;
        }

        public async Task<PaginatedResultDto<TransactionHistoryDto>> Handle(GetListTransactionHistoryIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
        {
            var query = _transactionhistoryRepository.GetListAsNoTracking(includeProperties: request.IncludeProperties).IgnoreQueryFilters()
                .Where(
                    x => (request.TransactionDate == null || x.TransactionDate == request.TransactionDate)
                    && (request.Total == null || x.Total == request.Total)
                    && (request.TransactionId == null || x.TransactionId == request.TransactionId)
                    && (request.CustomerId == null || x.CustomerId == request.CustomerId)
                    && x.IsDeleted == request.IsDeleted);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            var result = _mapper.Map<List<TransactionHistoryDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<TransactionHistoryDto>(result, totalCount);
        }
    }
}