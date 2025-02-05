using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Points.Queries.GetListPoint
{
    public class GetListPointQuery : PaginatedQuery<PaginatedResultDto<PointDto>>
    {
        public int? Score { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public Guid? CustomerId { get; set; }
    }
}