using Pizza4Ps.CustomerService.Domain.Abstractions;

namespace Pizza4Ps.CustomerService.Domain.Entities
{
    public class District : EntityAuditBase<Guid>
    {
        public string Name { get; set; }
        public Guid ProvinceId { get; set; }

        public virtual Province Province { get; set; }

        public District()
        {
        }

        public District(Guid id, string name, Guid provinceId)
        {
            Id = id;
            Name = name;
            ProvinceId = provinceId;
        }

        public void UpdateDistrict(string name, Guid provinceId)
        {
            Name = name;
            ProvinceId = provinceId;
        }
    }
}
