using Pizza4Ps.CustomerService.Domain.Abstractions;

namespace Pizza4Ps.CustomerService.Domain.Entities
{
    public class Ward : EntityAuditBase<Guid>
    {
        public string Name { get; set; }
        public Guid DistrictId { get; set; }

        public virtual District District { get; set; }

        public Ward()
        {
        }

        public Ward(Guid id, string name, Guid districtId)
        {
            Id = id;
            Name = name;
            DistrictId = districtId;
        }

        public void UpdateWard(string name, Guid districtId)
        {
            Name = name;
            DistrictId = districtId;
        }
    }
}
