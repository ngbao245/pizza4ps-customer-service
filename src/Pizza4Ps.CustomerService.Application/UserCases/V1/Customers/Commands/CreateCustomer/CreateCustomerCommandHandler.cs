using MediatR;
using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Domain.Abstractions.Services;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, ResultDto<Guid>>
    {
        private readonly ICustomerService _customerService;

        public CreateCustomerCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<ResultDto<Guid>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var result = await _customerService.CreateAsync(
                request.FirstName,
                request.LastName,
                request.Gender,
                request.DateOfBirth,
                request.Email,
                request.PhoneNumber,
                request.Avatar,
                request.StreetId);
            return new ResultDto<Guid>
            {
                Id = result
            };
        }
    }
}