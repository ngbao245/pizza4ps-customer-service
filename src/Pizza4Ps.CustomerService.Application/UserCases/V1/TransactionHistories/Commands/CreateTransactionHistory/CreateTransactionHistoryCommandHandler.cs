using MediatR;
using Pizza4Ps.CustomerService.Application.UserCases.V1.TransactionHistories.Commands.CreateTransactionHistory;
using Pizza4Ps.CustomerService.Domain.Abstractions.Services;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.TransactionHistories.Commands.CreateTransactionHistory
{
    public class CreateTransactionHistoryCommandHandler : IRequestHandler<CreateTransactionHistoryCommand, CreateTransactionHistoryCommandResponse>
    {
        private readonly ITransactionHistoryService _transactionhistoryService;

        public CreateTransactionHistoryCommandHandler(ITransactionHistoryService transactionhistoryService)
        {
            _transactionhistoryService = transactionhistoryService;
        }

        public async Task<CreateTransactionHistoryCommandResponse> Handle(CreateTransactionHistoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _transactionhistoryService.CreateAsync(
                request.CreateTransactionHistoryDto.TransactionDate,
                request.CreateTransactionHistoryDto.Total,
                request.CreateTransactionHistoryDto.TransactionId,
                request.CreateTransactionHistoryDto.CustomerId);
            return new CreateTransactionHistoryCommandResponse
            {
                Id = result
            };
        }
    }
}