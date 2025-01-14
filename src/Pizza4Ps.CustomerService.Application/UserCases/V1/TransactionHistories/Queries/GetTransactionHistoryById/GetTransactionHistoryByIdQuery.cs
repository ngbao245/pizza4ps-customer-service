using MediatR;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.TransactionHistories.Queries.GetTransactionHistoryById
{
    public class GetTransactionHistoryByIdQuery : IRequest<GetTransactionHistoryByIdQueryResponse>
    {
        public Guid Id { get; set; }
        public string includeProperties { get; set; } = "";
    }
}