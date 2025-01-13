using Pizza4Ps.CustomerService.Application.Abstractions;

namespace Pizza4Ps.CustomerService.Application.DTOs.Districts
{
    public class GetListDistrictIgnoreQueryFilterDto : PaginatedRequestDto
    {
        public bool IsDeleted { get; set; } = false;
        public string? Name { get; set; }
        public Guid? ProvinceId { get; set; }
    }
}
