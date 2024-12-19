namespace Pizza4Ps.CustomerService.Application.Abstractions
{
    public abstract class PaginatedRequestDto
    {
        public int TakeCount { get; set; } = 20;
        public int SkipCount { get; set; } = 0;
        public string SortBy { get; set; } = "Id Desc";
        public string includeProperties { get; set; } = "";
    }
}
