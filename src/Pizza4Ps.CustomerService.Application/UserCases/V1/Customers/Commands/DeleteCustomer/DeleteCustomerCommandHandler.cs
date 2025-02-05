using MediatR;
using Pizza4Ps.CustomerService.Domain.Abstractions.Services;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly ICustomerService _customerService;

        public DeleteCustomerCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            await _customerService.DeleteAsync(request.Ids, request.isHardDelete);
        }
    }
}