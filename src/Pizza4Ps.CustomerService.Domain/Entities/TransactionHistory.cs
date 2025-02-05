using Pizza4Ps.CustomerService.Domain.Abstractions;

namespace Pizza4Ps.CustomerService.Domain.Entities
{
    public class TransactionHistory : EntityAuditBase<Guid>
    {
        public DateTime TransactionDate { get; set; }
        public decimal Total { get; set; }
        public Guid TransactionId { get; set; }
        public Guid CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public TransactionHistory()
        {
        }

        public TransactionHistory(Guid id, DateTime transactionDate, decimal total, Guid transactionId, Guid customerId)
        {
            Id = id;
            TransactionDate = transactionDate;
            Total = total;
            TransactionId = transactionId;
            CustomerId = customerId;
        }

        public void UpdateTransactionHistory(DateTime transactionDate, decimal total, Guid transactionId, Guid customerId)
        {
            TransactionDate = transactionDate;
            Total = total;
            TransactionId = transactionId;
            CustomerId = customerId;
        }
    }
}
