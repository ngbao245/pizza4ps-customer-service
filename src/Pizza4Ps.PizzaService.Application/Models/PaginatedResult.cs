namespace Pizza4Ps.PizzaService.Application.Models
{
    public class PaginatedResult<T>
    {
        public List<T> Items { get; }
        public long TotalCount { get; }

        public PaginatedResult(List<T> items, long totalCount)
        {
            Items = items;
            TotalCount = totalCount;
        }
    }
}
