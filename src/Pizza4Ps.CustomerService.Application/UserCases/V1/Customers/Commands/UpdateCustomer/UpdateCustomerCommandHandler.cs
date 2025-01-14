using MediatR;
using Pizza4Ps.CustomerService.Domain.Abstractions.Services;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, UpdateCustomerCommandResponse>
    {
        private readonly ICustomerService _customerService;

        public UpdateCustomerCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<UpdateCustomerCommandResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var result = await _customerService.UpdateAsync(
                request.Id,
                request.UpdateCustomerDto.FirstName,
                request.UpdateCustomerDto.LastName,
                request.UpdateCustomerDto.Gender,
                request.UpdateCustomerDto.DateOfBirth,
                request.UpdateCustomerDto.Email,
                request.UpdateCustomerDto.PhoneNumber,
                request.UpdateCustomerDto.Avatar,
                request.UpdateCustomerDto.StreetId);
            return new UpdateCustomerCommandResponse
            {
                Id = result
            };
        }
    }
}