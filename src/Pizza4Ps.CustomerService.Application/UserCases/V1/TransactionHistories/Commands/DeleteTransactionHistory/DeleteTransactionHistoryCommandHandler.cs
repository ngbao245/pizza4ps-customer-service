using MediatR;
using Pizza4Ps.CustomerService.Domain.Abstractions.Services;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.TransactionHistories.Commands.DeleteTransactionHistory
{
    public class DeleteTransactionHistoryCommandHandler : IRequestHandler<DeleteTransactionHistoryCommand>
    {
        private readonly ITransactionHistoryService _transactionhistoryService;

        public DeleteTransactionHistoryCommandHandler(ITransactionHistoryService transactionhistoryService)
        {
            _transactionhistoryService = transactionhistoryService;
        }

        public async Task Handle(DeleteTransactionHistoryCommand request, CancellationToken cancellationToken)
        {
            await _transactionhistoryService.DeleteAsync(request.Ids, request.isHardDelete);
        }
    }
}