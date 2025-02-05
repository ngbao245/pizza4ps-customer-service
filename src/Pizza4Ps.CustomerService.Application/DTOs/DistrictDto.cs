using Pizza4Ps.CustomerService.Domain.Entities;

namespace Pizza4Ps.CustomerService.Application.DTOs.Districts
{
    public class DistrictDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ProvinceId { get; set; }

        public virtual Province Province { get; set; }
    }
}
