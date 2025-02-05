using MediatR;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Customers.Commands.RestoreCustomer
{
    public class RestoreCustomerCommand : IRequest
    {
        public List<Guid> Ids { get; set; }
    }
}
