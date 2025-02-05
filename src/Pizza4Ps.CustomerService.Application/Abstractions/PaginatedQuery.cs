using MediatR;

namespace Pizza4Ps.CustomerService.Application.Abstractions
{
    public class PaginatedQuery<TResponse> : IRequest<TResponse>
    {
        public int TakeCount { get; set; } = 20;
        public int SkipCount { get; set; } = 0;
        public string SortBy { get; set; } = "Id Desc";
        public string IncludeProperties { get; set; } = "";
    }
}
