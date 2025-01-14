using MediatR;
using Pizza4Ps.CustomerService.Domain.Abstractions.Services;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerCommandResponse>
    {
        private readonly ICustomerService _customerService;

        public CreateCustomerCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var result = await _customerService.CreateAsync(
                request.CreateCustomerDto.FirstName,
                request.CreateCustomerDto.LastName,
                request.CreateCustomerDto.Gender,
                request.CreateCustomerDto.DateOfBirth,
                request.CreateCustomerDto.Email,
                request.CreateCustomerDto.PhoneNumber,
                request.CreateCustomerDto.Avatar,
                request.CreateCustomerDto.StreetId);
            return new CreateCustomerCommandResponse
            {
                Id = result
            };
        }
    }
}