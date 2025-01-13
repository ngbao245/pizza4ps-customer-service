using Pizza4Ps.CustomerService.Application.Abstractions;

namespace Pizza4Ps.CustomerService.Application.DTOs.Provinces
{
    public class GetListProvinceDto : PaginatedRequestDto
    {
        public string? Name { get; set; }
    }
}
