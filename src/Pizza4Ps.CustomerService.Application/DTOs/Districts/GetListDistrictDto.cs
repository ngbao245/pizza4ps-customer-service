using Pizza4Ps.CustomerService.Application.Abstractions;

namespace Pizza4Ps.CustomerService.Application.DTOs.Districts
{
    public class GetListDistrictDto : PaginatedRequestDto
    {
        public string? Name { get; set; }
        public Guid? ProvinceId { get; set; }
    }
}
