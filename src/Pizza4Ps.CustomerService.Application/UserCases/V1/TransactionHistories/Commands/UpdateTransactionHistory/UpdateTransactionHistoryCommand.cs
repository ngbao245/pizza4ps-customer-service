using MediatR;
using Pizza4Ps.CustomerService.Application.DTOs.TransactionHistories;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.TransactionHistories.Commands.UpdateTransactionHistory
{
    public class UpdateTransactionHistoryCommand : IRequest<UpdateTransactionHistoryCommandResponse>
    {
        public Guid Id { get; set; }
        public UpdateTransactionHistoryDto UpdateTransactionHistoryDto { get; set; }
    }
}