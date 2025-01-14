using MediatR;
using Pizza4Ps.CustomerService.Domain.Abstractions.Services;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.TransactionHistories.Commands.UpdateTransactionHistory
{
    public class UpdateTransactionHistoryCommandHandler : IRequestHandler<UpdateTransactionHistoryCommand, UpdateTransactionHistoryCommandResponse>
    {
        private readonly ITransactionHistoryService _transactionhistoryService;

        public UpdateTransactionHistoryCommandHandler(ITransactionHistoryService transactionhistoryService)
        {
            _transactionhistoryService = transactionhistoryService;
        }

        public async Task<UpdateTransactionHistoryCommandResponse> Handle(UpdateTransactionHistoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _transactionhistoryService.UpdateAsync(
                request.Id,
                request.UpdateTransactionHistoryDto.TransactionDate,
                request.UpdateTransactionHistoryDto.Total,
                request.UpdateTransactionHistoryDto.TransactionId,
                request.UpdateTransactionHistoryDto.CustomerId);
            return new UpdateTransactionHistoryCommandResponse
            {
                Id = result
            };
        }
    }
}