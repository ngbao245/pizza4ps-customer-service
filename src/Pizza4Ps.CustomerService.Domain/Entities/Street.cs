using Pizza4Ps.CustomerService.Domain.Abstractions;

namespace Pizza4Ps.CustomerService.Domain.Entities
{
    public class Street : EntityAuditBase<Guid>
    {
        public string Name { get; set; }
        public Guid WardId { get; set; }

        public virtual Ward Ward { get; set; }

        public Street()
        {
        }

        public Street(Guid id, string name, Guid wardId)
        {
            Id = id;
            Name = name;
            WardId = wardId;
        }

        public void UpdateStreet(string name, Guid wardId)
        {
            Name = name;
            WardId = wardId;
        }
    }
}
