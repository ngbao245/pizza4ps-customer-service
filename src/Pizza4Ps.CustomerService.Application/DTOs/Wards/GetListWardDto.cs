using Pizza4Ps.CustomerService.Application.Abstractions;

namespace Pizza4Ps.CustomerService.Application.DTOs.Wards
{
    public class GetListWardDto : PaginatedRequestDto
    {
        public string Name { get; set; }
        public Guid DistrictId { get; set; }
    }
}
