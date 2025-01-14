using MediatR;
using Pizza4Ps.CustomerService.Application.DTOs.Customers;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<CreateCustomerCommandResponse>
    {
        public CreateCustomerDto CreateCustomerDto { get; set; }
    }

}
