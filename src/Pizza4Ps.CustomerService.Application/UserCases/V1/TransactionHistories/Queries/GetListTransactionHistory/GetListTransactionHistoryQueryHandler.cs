using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.CustomerService.Application.DTOs.TransactionHistories;
using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using Pizza4Ps.CustomerService.Domain.Constants;
using Pizza4Ps.CustomerService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.TransactionHistories.Queries.GetListTransactionHistory
{
    public class GetListTransactionHistoryQueryHandler : IRequestHandler<GetListTransactionHistoryQuery, GetListTransactionHistoryQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITransactionHistoryRepository _transactionhistoryRepository;

        public GetListTransactionHistoryQueryHandler(IMapper mapper, ITransactionHistoryRepository transactionhistoryRepository)
        {
            _mapper = mapper;
            _transactionhistoryRepository = transactionhistoryRepository;
        }

        public async Task<GetListTransactionHistoryQueryResponse> Handle(GetListTransactionHistoryQuery request, CancellationToken cancellationToken)
        {
            var query = _transactionhistoryRepository.GetListAsNoTracking(
                x => (request.GetListTransactionHistoryDto.TransactionDate == null || x.TransactionDate == request.GetListTransactionHistoryDto.TransactionDate)
                && (request.GetListTransactionHistoryDto.Total == null || x.Total == request.GetListTransactionHistoryDto.Total)
                && (request.GetListTransactionHistoryDto.TransactionId == null || x.TransactionId == request.GetListTransactionHistoryDto.TransactionId)
                && (request.GetListTransactionHistoryDto.CustomerId == null || x.CustomerId == request.GetListTransactionHistoryDto.CustomerId),
                includeProperties: request.GetListTransactionHistoryDto.includeProperties);
            var entities = await query
                .OrderBy(request.GetListTransactionHistoryDto.SortBy)
                .Skip(request.GetListTransactionHistoryDto.SkipCount).Take(request.GetListTransactionHistoryDto.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.TransactionHistoryErrorConstant.TRANSACTION_HISTORY_NOT_FOUND);
            var result = _mapper.Map<List<TransactionHistoryDto>>(entities);
            var totalCount = await query.CountAsync();
            return new GetListTransactionHistoryQueryResponse(result, totalCount);
        }
    }
}