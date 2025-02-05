using MediatR;
using Pizza4Ps.CustomerService.Domain.Abstractions.Services;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.TransactionHistories.Commands.RestoreTransactionHistory
{
    public class RestoreTransactionHistoryCommandHandler : IRequestHandler<RestoreTransactionHistoryCommand>
    {
        private readonly ITransactionHistoryService _transactionhistoryService;

        public RestoreTransactionHistoryCommandHandler(ITransactionHistoryService transactionhistoryService)
        {
            _transactionhistoryService = transactionhistoryService;
        }

        public async Task Handle(RestoreTransactionHistoryCommand request, CancellationToken cancellationToken)
        {
            await _transactionhistoryService.RestoreAsync(request.Ids);
        }
    }
}