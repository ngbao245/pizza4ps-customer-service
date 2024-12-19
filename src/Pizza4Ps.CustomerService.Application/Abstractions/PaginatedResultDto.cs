namespace Pizza4Ps.CustomerService.Application.Abstractions
{
    public class PaginatedResultDto<T>
    {
        public List<T> Items { get; }
        public long TotalCount { get; }

        public PaginatedResultDto(List<T> items, long totalCount)
        {
            Items = items;
            TotalCount = totalCount;
        }
    }
}
