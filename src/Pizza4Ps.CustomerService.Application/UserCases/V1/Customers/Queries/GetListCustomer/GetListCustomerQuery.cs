using MediatR;
using Pizza4Ps.CustomerService.Application.DTOs.Customers;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Customers.Queries.GetListCustomer
{
    public class GetListCustomerQuery : IRequest<GetListCustomerQueryResponse>
    {
        public GetListCustomerDto GetListCustomerDto { get; set; }
    }
}