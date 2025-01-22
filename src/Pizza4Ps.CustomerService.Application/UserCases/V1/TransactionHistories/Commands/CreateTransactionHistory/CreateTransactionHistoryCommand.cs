using MediatR;
using Pizza4Ps.CustomerService.Application.Abstractions;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.TransactionHistories.Commands.CreateTransactionHistory
{
    public class CreateTransactionHistoryCommand : IRequest<ResultDto<Guid>>
    {
        public DateTime TransactionDate { get; set; }
        public decimal Total { get; set; }
        public Guid TransactionId { get; set; }
        public Guid CustomerId { get; set; }
    }

}
