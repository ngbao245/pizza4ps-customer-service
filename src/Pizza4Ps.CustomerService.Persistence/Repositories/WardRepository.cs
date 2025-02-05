using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using Pizza4Ps.CustomerService.Domain.Entities;

namespace Pizza4Ps.CustomerService.Persistence.Repositories
{
    public class WardRepository : RepositoryBase<Ward, Guid>, IWardRepository
    {
        public WardRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
