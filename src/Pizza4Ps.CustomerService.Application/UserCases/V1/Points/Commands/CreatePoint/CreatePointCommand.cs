using MediatR;
using Pizza4Ps.CustomerService.Application.Abstractions;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Points.Commands.CreatePoint
{
    public class CreatePointCommand : IRequest<ResultDto<Guid>>
    {
        public int Score { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Guid CustomerId { get; set; }
    }
}
