using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs.Customers;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Customers.Queries.GetListCustomerIgnoreQueryFilter
{
    public class GetListCustomerIgnoreQueryFilterQueryResponse : PaginatedResultDto<CustomerDto>
    {
        public GetListCustomerIgnoreQueryFilterQueryResponse(List<CustomerDto> items, long totalCount) : base(items, totalCount)
        {
        }
    }
}