namespace Pizza4Ps.CustomerService.Domain.Abstractions.Entities
{
    public interface IEntityBase<TKey>
    {
        TKey Id { get; }
    }
}
