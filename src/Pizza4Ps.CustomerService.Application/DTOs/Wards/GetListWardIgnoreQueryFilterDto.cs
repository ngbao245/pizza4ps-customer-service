using Pizza4Ps.CustomerService.Application.Abstractions;

namespace Pizza4Ps.CustomerService.Application.DTOs.Wards
{
    public class GetListWardIgnoreQueryFilterDto : PaginatedRequestDto
    {
        public bool IsDeleted { get; set; } = false;
        public string Name { get; set; }
        public Guid DistrictId { get; set; }
    }
}
