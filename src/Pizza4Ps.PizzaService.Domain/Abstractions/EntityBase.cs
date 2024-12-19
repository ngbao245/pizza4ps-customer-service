using Pizza4Ps.PizzaService.Domain.Abstractions.Entities;

namespace Pizza4Ps.PizzaService.Domain.Abstractions
{
    public abstract class EntityBase<TKey> : IEntityBase<TKey>
    {
        public TKey Id { get; set; }
    }
}
