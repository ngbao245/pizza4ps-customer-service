using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs;
using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using Pizza4Ps.CustomerService.Domain.Constants;
using Pizza4Ps.CustomerService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.TransactionHistories.Queries.GetListTransactionHistory
{
    public class GetListTransactionHistoryQueryHandler : IRequestHandler<GetListTransactionHistoryQuery, PaginatedResultDto<TransactionHistoryDto>>
    {
        private readonly IMapper _mapper;
        private readonly ITransactionHistoryRepository _transactionhistoryRepository;

        public GetListTransactionHistoryQueryHandler(IMapper mapper, ITransactionHistoryRepository transactionhistoryRepository)
        {
            _mapper = mapper;
            _transactionhistoryRepository = transactionhistoryRepository;
        }

        public async Task<PaginatedResultDto<TransactionHistoryDto>> Handle(GetListTransactionHistoryQuery request, CancellationToken cancellationToken)
        {
            var query = _transactionhistoryRepository.GetListAsNoTracking(
                x => (request.TransactionDate == null || x.TransactionDate == request.TransactionDate)
                && (request.Total == null || x.Total == request.Total)
                && (request.TransactionId == null || x.TransactionId == request.TransactionId)
                && (request.CustomerId == null || x.CustomerId == request.CustomerId),
                includeProperties: request.IncludeProperties);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.TransactionHistoryErrorConstant.TRANSACTION_HISTORY_NOT_FOUND);
            var result = _mapper.Map<List<TransactionHistoryDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<TransactionHistoryDto>(result, totalCount);
        }
    }
}