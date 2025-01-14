using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs.Customers;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Customers.Queries.GetListCustomer
{
    public class GetListCustomerQueryResponse : PaginatedResultDto<CustomerDto>
    {
        public GetListCustomerQueryResponse(List<CustomerDto> items, long totalCount) : base(items, totalCount)
        {
        }
    }
}