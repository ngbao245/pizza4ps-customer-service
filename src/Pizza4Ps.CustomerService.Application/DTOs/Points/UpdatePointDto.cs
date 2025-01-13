namespace Pizza4Ps.CustomerService.Application.DTOs.Points
{
    public class UpdatePointDto
    {
        public int Score { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Guid CustomerId { get; set; }
    }
}
