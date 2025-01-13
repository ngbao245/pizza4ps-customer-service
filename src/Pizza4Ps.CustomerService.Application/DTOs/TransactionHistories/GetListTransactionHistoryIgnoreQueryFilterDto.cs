using Pizza4Ps.CustomerService.Application.Abstractions;

namespace Pizza4Ps.CustomerService.Application.DTOs.TransactionHistories
{
    public class GetListTransactionHistoryIgnoreQueryFilterDto : PaginatedRequestDto
    {
        public bool IsDeleted { get; set; } = false;
        public DateTime? TransactionDate { get; set; }
        public decimal? Total { get; set; }
        public Guid? TransactionId { get; set; }
        public Guid? CustomerId { get; set; }
    }
}
