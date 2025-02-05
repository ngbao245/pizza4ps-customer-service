using MediatR;
using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.TransactionHistories.Queries.GetListTransactionHistoryIgnoreQueryFilter
{
    public class GetListTransactionHistoryIgnoreQueryFilterQuery : PaginatedQuery<PaginatedResultDto<TransactionHistoryDto>>
    {
        public bool IsDeleted { get; set; } = false;
        public DateTime? TransactionDate { get; set; }
        public decimal? Total { get; set; }
        public Guid? TransactionId { get; set; }
        public Guid? CustomerId { get; set; }
    }
}