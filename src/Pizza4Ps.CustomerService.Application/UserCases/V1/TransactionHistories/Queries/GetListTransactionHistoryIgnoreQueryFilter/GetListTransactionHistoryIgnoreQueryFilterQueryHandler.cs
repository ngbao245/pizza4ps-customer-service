using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.CustomerService.Application.DTOs.TransactionHistories;
using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.TransactionHistories.Queries.GetListTransactionHistoryIgnoreQueryFilter
{
    public class GetListTransactionHistoryIgnoreQueryFilterQueryHandler : IRequestHandler<GetListTransactionHistoryIgnoreQueryFilterQuery, GetListTransactionHistoryIgnoreQueryFilterQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITransactionHistoryRepository _transactionhistoryRepository;

        public GetListTransactionHistoryIgnoreQueryFilterQueryHandler(IMapper mapper, ITransactionHistoryRepository transactionhistoryRepository)
        {
            _mapper = mapper;
            _transactionhistoryRepository = transactionhistoryRepository;
        }

        public async Task<GetListTransactionHistoryIgnoreQueryFilterQueryResponse> Handle(GetListTransactionHistoryIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
        {
            var query = _transactionhistoryRepository.GetListAsNoTracking(includeProperties: request.GetListTransactionHistoryIgnoreQueryFilterDto.includeProperties).IgnoreQueryFilters()
                .Where(
                    x => (request.GetListTransactionHistoryIgnoreQueryFilterDto.TransactionDate == null || x.TransactionDate == request.GetListTransactionHistoryIgnoreQueryFilterDto.TransactionDate)
                    && (request.GetListTransactionHistoryIgnoreQueryFilterDto.Total == null || x.Total == request.GetListTransactionHistoryIgnoreQueryFilterDto.Total)
                    && (request.GetListTransactionHistoryIgnoreQueryFilterDto.TransactionId == null || x.TransactionId == request.GetListTransactionHistoryIgnoreQueryFilterDto.TransactionId)
                    && (request.GetListTransactionHistoryIgnoreQueryFilterDto.CustomerId == null || x.CustomerId == request.GetListTransactionHistoryIgnoreQueryFilterDto.CustomerId)
                    && x.IsDeleted == request.GetListTransactionHistoryIgnoreQueryFilterDto.IsDeleted);
            var entities = await query
                .OrderBy(request.GetListTransactionHistoryIgnoreQueryFilterDto.SortBy)
                .Skip(request.GetListTransactionHistoryIgnoreQueryFilterDto.SkipCount).Take(request.GetListTransactionHistoryIgnoreQueryFilterDto.TakeCount).ToListAsync();
            var result = _mapper.Map<List<TransactionHistoryDto>>(entities);
            var totalCount = await query.CountAsync();
            return new GetListTransactionHistoryIgnoreQueryFilterQueryResponse(result, totalCount);
        }
    }
}