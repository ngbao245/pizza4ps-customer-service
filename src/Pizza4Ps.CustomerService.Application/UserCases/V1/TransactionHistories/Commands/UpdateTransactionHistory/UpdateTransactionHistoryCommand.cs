using MediatR;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.TransactionHistories.Commands.UpdateTransactionHistory
{
    public class UpdateTransactionHistoryCommand : IRequest
    {
        public Guid? Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Total { get; set; }
        public Guid TransactionId { get; set; }
        public Guid CustomerId { get; set; }
    }
}