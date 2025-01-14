using MediatR;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerCommandResponse>
    {
        //public CreateCustomerCommandHandler(ICustomerService customerService)
        //{
        //    _customerService = customerService;
        //}

        //public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        //{
        //    var result = await _customerService.CreateAsync(
        //        request.CreateCustomerDto.FullName,
        //        request.CreateCustomerDto.Phone);
        //    return new CreateCustomerCommandResponse
        //    {
        //        Id = result
        //    };
        //}
    }
}
