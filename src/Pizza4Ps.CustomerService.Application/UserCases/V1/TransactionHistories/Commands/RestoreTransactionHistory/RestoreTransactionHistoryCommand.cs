using MediatR;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.TransactionHistories.Commands.RestoreTransactionHistory
{
    public class RestoreTransactionHistoryCommand : IRequest
    {
        public List<Guid> Ids { get; set; }
    }
}
