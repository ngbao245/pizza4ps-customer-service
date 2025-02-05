using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using Pizza4Ps.CustomerService.Domain.Entities;

namespace Pizza4Ps.CustomerService.Persistence.Repositories
{
    public class StreetRepository : RepositoryBase<Street, Guid>, IStreetRepository
    {
        public StreetRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
