using Pizza4Ps.PizzaService.Domain.Abstractions.Entities;

namespace Pizza4Ps.PizzaService.Domain.Abstractions
{
    public abstract class EntityAuditBase<TKey> : EntityBase<TKey>, IEntityAuditBase<TKey>
    {
        public DateTimeOffset CreatedDate { get ; set ; }
        public DateTimeOffset? ModifiedDate { get ; set ; }
        public string? CreatedBy { get ; set ; }
        public string? ModifiedBy { get ; set ; }
        public bool IsDeleted { get ; set ; }
        public DateTimeOffset? DeletedAt { get ; set ; }
        public string? DeletedBy { get ; set ; }
    }
}
