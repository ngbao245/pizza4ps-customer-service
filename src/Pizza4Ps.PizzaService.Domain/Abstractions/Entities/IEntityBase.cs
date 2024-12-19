namespace Pizza4Ps.PizzaService.Domain.Abstractions.Entities
{
    public interface IEntityBase<TKey>
    {
        TKey Id { get; }
    }
}
