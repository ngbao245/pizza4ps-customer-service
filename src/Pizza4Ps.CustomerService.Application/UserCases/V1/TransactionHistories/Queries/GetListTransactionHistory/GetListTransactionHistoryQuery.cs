using MediatR;
using Pizza4Ps.CustomerService.Application.DTOs.TransactionHistories;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.TransactionHistories.Queries.GetListTransactionHistory
{
    public class GetListTransactionHistoryQuery : IRequest<GetListTransactionHistoryQueryResponse>
    {
        public GetListTransactionHistoryDto GetListTransactionHistoryDto { get; set; }
    }
}