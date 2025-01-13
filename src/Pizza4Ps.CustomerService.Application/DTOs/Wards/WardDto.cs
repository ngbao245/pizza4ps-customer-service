using Pizza4Ps.CustomerService.Domain.Entities;

namespace Pizza4Ps.CustomerService.Application.DTOs.Wards
{
    public class WardDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid DistrictId { get; set; }

        public virtual District District { get; set; }
    }
}
