using Pizza4Ps.CustomerService.Application.Abstractions;

namespace Pizza4Ps.CustomerService.Application.DTOs.TransactionHistories
{
    public class GetListTransactionHistoryDto : PaginatedRequestDto
    {
        public DateTime? TransactionDate { get; set; }
        public decimal? Total { get; set; }
        public Guid? TransactionId { get; set; }
        public Guid? CustomerId { get; set; }
    }
}
