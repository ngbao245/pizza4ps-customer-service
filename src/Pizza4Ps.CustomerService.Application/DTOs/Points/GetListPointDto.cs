using Pizza4Ps.CustomerService.Application.Abstractions;

namespace Pizza4Ps.CustomerService.Application.DTOs.Points
{
    public class GetListPointDto : PaginatedRequestDto
    {
        public int? Score { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public Guid? CustomerId { get; set; }
    }
}
