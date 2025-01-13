using Pizza4Ps.CustomerService.Domain.Entities;

namespace Pizza4Ps.CustomerService.Application.DTOs.Streets
{
    public class StreetDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid WardId { get; set; }

        public virtual Ward Ward { get; set; }
    }
}
