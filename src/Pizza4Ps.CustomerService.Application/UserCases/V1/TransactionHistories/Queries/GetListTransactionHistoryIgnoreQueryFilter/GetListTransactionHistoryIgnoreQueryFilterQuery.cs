using MediatR;
using Pizza4Ps.CustomerService.Application.DTOs.TransactionHistories;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.TransactionHistories.Queries.GetListTransactionHistoryIgnoreQueryFilter
{
    public class GetListTransactionHistoryIgnoreQueryFilterQuery : IRequest<GetListTransactionHistoryIgnoreQueryFilterQueryResponse>
    {
        public GetListTransactionHistoryIgnoreQueryFilterDto GetListTransactionHistoryIgnoreQueryFilterDto { get; set; }
    }
}