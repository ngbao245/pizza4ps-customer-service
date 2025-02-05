using Pizza4Ps.CustomerService.Domain.Abstractions;

namespace Pizza4Ps.CustomerService.Domain.Entities
{
    public class Province : EntityAuditBase<Guid>
    {
        public string Name { get; set; }

        public Province()
        {
        }

        public Province(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public void UpdateProvince(string name)
        {
            Name = name;
        }
    }
}
