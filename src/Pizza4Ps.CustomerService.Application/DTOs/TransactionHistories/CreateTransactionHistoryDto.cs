namespace Pizza4Ps.CustomerService.Application.DTOs.TransactionHistories
{
    public class CreateTransactionHistoryDto
    {
        public DateTime TransactionDate { get; set; }
        public decimal Total { get; set; }
        public Guid TransactionId { get; set; }
        public Guid CustomerId { get; set; }
    }
}
