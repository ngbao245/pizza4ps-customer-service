using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using Pizza4Ps.CustomerService.Domain.Entities;

namespace Pizza4Ps.CustomerService.Persistence.Repositories
{
    public class TransactionHistoryRepository : RepositoryBase<TransactionHistory, Guid>, ITransactionHistoryRepository
    {
        public TransactionHistoryRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
