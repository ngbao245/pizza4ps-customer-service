using MediatR;
using Pizza4Ps.CustomerService.Application.DTOs;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.TransactionHistories.Queries.GetTransactionHistoryById
{
    public class GetTransactionHistoryByIdQuery : IRequest<TransactionHistoryDto>
    {
        public Guid Id { get; set; }
        public string IncludeProperties { get; set; } = "";
    }
}