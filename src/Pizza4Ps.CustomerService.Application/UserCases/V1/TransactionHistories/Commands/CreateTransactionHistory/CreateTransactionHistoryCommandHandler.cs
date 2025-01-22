using MediatR;
using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Domain.Abstractions.Services;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.TransactionHistories.Commands.CreateTransactionHistory
{
    public class CreateTransactionHistoryCommandHandler : IRequestHandler<CreateTransactionHistoryCommand, ResultDto<Guid>>
    {
        private readonly ITransactionHistoryService _transactionhistoryService;

        public CreateTransactionHistoryCommandHandler(ITransactionHistoryService transactionhistoryService)
        {
            _transactionhistoryService = transactionhistoryService;
        }

        public async Task<ResultDto<Guid>> Handle(CreateTransactionHistoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _transactionhistoryService.CreateAsync(
                request.TransactionDate,
                request.Total,
                request.TransactionId,
                request.CustomerId);
            return new ResultDto<Guid>
            {
                Id = result
            };
        }
    }
}