using Pizza4Ps.CustomerService.Application.DTOs.Customers;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdQueryResponse
    {
        public CustomerDto Customer { get; set; }
    }
}
