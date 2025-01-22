using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Points.Queries.GetListPointIgnoreQueryFilter
{
    public class GetListPointIgnoreQueryFilterQuery : PaginatedQuery<PaginatedResultDto<PointDto>>
    {
        public bool IsDeleted { get; set; } = false;
        public int? Score { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public Guid? CustomerId { get; set; }
    }
}