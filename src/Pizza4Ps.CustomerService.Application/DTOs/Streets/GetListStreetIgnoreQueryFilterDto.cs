using Pizza4Ps.CustomerService.Application.Abstractions;

namespace Pizza4Ps.CustomerService.Application.DTOs.Streets
{
    public class GetListStreetIgnoreQueryFilterDto : PaginatedRequestDto
    {
        public bool IsDeleted { get; set; } = false;
        public string? Name { get; set; }
        public Guid? WardId { get; set; }
    }
}
