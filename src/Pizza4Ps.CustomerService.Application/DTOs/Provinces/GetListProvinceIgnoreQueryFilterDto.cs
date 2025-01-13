using Pizza4Ps.CustomerService.Application.Abstractions;

namespace Pizza4Ps.CustomerService.Application.DTOs.Provinces
{
    public class GetListProvinceIgnoreQueryFilterDto : PaginatedRequestDto
    {
        public bool IsDeleted { get; set; } = false;
        public string? Name { get; set; }
    }
}