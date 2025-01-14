using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs.TransactionHistories;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.TransactionHistories.Queries.GetListTransactionHistoryIgnoreQueryFilter
{
    public class GetListTransactionHistoryIgnoreQueryFilterQueryResponse : PaginatedResultDto<TransactionHistoryDto>
    {
        public GetListTransactionHistoryIgnoreQueryFilterQueryResponse(List<TransactionHistoryDto> items, long totalCount) : base(items, totalCount)
        {
        }
    }
}