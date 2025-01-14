using AutoMapper;
using MediatR;
using Pizza4Ps.CustomerService.Application.DTOs.TransactionHistories;
using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.TransactionHistories.Queries.GetTransactionHistoryById
{
    public class GetTransactionHistoryByIdQueryHandler : IRequestHandler<GetTransactionHistoryByIdQuery, GetTransactionHistoryByIdQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITransactionHistoryRepository _transactionhistoryRepository;

        public GetTransactionHistoryByIdQueryHandler(IMapper mapper, ITransactionHistoryRepository transactionhistoryRepository)
        {
            _mapper = mapper;
            _transactionhistoryRepository = transactionhistoryRepository;
        }

        public async Task<GetTransactionHistoryByIdQueryResponse> Handle(GetTransactionHistoryByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _transactionhistoryRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
            var result = _mapper.Map<TransactionHistoryDto>(entity);
            return new GetTransactionHistoryByIdQueryResponse
            {
                TransactionHistory = result
            };
        }
    }
}