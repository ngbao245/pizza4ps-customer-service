using Pizza4Ps.CustomerService.Domain.Abstractions;

namespace Pizza4Ps.CustomerService.Domain.Entities
{
    public class Point : EntityAuditBase<Guid>
    {
        public int Score { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Guid CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public Point()
        {
        }

        public Point(Guid id, int score, DateTime expiryDate, Guid customerId)
        {
            Id = id;
            Score = score;
            ExpiryDate = expiryDate;
            CustomerId = customerId;
        }

        public void UpdatePoint(int score, DateTime expiryDate, Guid customerId)
        {
            Score = score;
            ExpiryDate = expiryDate;
            CustomerId = customerId;
        }
    }
}
