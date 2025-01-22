using MediatR;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Points.Commands.UpdatePoint
{
    public class UpdatePointCommand : IRequest
    {
        public Guid? Id { get; set; }
        public int Score { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Guid CustomerId { get; set; }
    }
}