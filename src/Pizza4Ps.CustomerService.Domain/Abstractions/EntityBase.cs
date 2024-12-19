using Pizza4Ps.CustomerService.Domain.Abstractions.Entities;

namespace Pizza4Ps.CustomerService.Domain.Abstractions
{
    public abstract class EntityBase<TKey> : IEntityBase<TKey>
    {
        public TKey Id { get; set; }
    }
}
