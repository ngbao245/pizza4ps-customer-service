using Pizza4Ps.CustomerService.Application.DTOs.TransactionHistories;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.TransactionHistories.Queries.GetTransactionHistoryById
{
    public class GetTransactionHistoryByIdQueryResponse
    {
        public TransactionHistoryDto TransactionHistory { get; set; }
    }
}
