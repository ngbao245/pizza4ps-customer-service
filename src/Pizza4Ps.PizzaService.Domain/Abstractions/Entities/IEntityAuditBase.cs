namespace Pizza4Ps.PizzaService.Domain.Abstractions.Entities
{
    public interface IEntityAuditBase<TKey> : IEntityBase<TKey>, IAuditable
    {
    }
}
