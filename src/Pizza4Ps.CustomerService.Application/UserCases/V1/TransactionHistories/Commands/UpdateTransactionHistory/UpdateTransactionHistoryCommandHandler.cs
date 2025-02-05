using MediatR;
using Pizza4Ps.CustomerService.Domain.Abstractions.Services;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.TransactionHistories.Commands.UpdateTransactionHistory
{
    public class UpdateTransactionHistoryCommandHandler : IRequestHandler<UpdateTransactionHistoryCommand>
    {
        private readonly ITransactionHistoryService _transactionhistoryService;

        public UpdateTransactionHistoryCommandHandler(ITransactionHistoryService transactionhistoryService)
        {
            _transactionhistoryService = transactionhistoryService;
        }

        public async Task Handle(UpdateTransactionHistoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _transactionhistoryService.UpdateAsync(
                request.Id!.Value,
                request.TransactionDate,
                request.Total,
                request.TransactionId,
                request.CustomerId);
        }
    }
}