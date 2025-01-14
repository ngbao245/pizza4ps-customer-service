using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs.TransactionHistories;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.TransactionHistories.Queries.GetListTransactionHistory
{
    public class GetListTransactionHistoryQueryResponse : PaginatedResultDto<TransactionHistoryDto>
    {
        public GetListTransactionHistoryQueryResponse(List<TransactionHistoryDto> items, long totalCount) : base(items, totalCount)
        {
        }
    }
}