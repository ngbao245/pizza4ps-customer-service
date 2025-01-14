using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using Pizza4Ps.CustomerService.Domain.Entities;

namespace Pizza4Ps.CustomerService.Persistence.Repositories
{
    public class VoucherRepository : RepositoryBase<Voucher, Guid>, IVoucherRepository
    {
        public VoucherRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
