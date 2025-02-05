using MediatR;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.TransactionHistories.Commands.DeleteTransactionHistory
{
    public class DeleteTransactionHistoryCommand : IRequest
    {
        public List<Guid> Ids { get; set; }
        public bool isHardDelete { get; set; }
    }
}