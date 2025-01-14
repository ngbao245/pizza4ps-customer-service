using MediatR;
using Pizza4Ps.CustomerService.Application.DTOs.TransactionHistories;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.TransactionHistories.Commands.CreateTransactionHistory
{
    public class CreateTransactionHistoryCommand : IRequest<CreateTransactionHistoryCommandResponse>
    {
        public CreateTransactionHistoryDto CreateTransactionHistoryDto { get; set; }
    }

}
