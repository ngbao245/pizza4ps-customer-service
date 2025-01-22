using MediatR;
using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.TransactionHistories.Queries.GetListTransactionHistory
{
    public class GetListTransactionHistoryQuery : PaginatedQuery<PaginatedResultDto<TransactionHistoryDto>>
    {
        public DateTime? TransactionDate { get; set; }
        public decimal? Total { get; set; }
        public Guid? TransactionId { get; set; }
        public Guid? CustomerId { get; set; }
    }
}