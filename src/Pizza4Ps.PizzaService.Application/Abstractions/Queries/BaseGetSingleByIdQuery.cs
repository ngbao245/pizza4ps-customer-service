namespace Pizza4Ps.PizzaService.Application.Abstractions.Queries
{
    public class BaseGetSingleByIdQuery<TKey>
    {
        public TKey Id { get; set; }
    }
}
