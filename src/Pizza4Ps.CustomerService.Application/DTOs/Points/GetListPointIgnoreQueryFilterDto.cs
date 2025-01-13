using Pizza4Ps.CustomerService.Application.Abstractions;

namespace Pizza4Ps.CustomerService.Application.DTOs.Points
{
    public class GetListPointIgnoreQueryFilterDto : PaginatedRequestDto
    {
        public bool IsDeleted { get; set; } = false;
        public int? Score { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public Guid? CustomerId { get; set; }
    }
}
