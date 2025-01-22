using Pizza4Ps.CustomerService.Domain.Entities;

namespace Pizza4Ps.CustomerService.Application.DTOs
{
    public class TransactionHistoryDto
    {
        public Guid Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Total { get; set; }
        public Guid TransactionId { get; set; }
        public Guid CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
