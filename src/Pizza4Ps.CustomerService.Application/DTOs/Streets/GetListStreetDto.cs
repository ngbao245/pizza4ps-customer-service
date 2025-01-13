using Pizza4Ps.CustomerService.Application.Abstractions;

namespace Pizza4Ps.CustomerService.Application.DTOs.Streets
{
    public class GetListStreetDto : PaginatedRequestDto
    {
        public string? Name { get; set; }
        public Guid? WardId { get; set; }
    }
}
