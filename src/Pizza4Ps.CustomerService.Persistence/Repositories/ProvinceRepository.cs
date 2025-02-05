using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using Pizza4Ps.CustomerService.Domain.Entities;

namespace Pizza4Ps.CustomerService.Persistence.Repositories
{
    public class ProvinceRepository : RepositoryBase<Province, Guid>, IProvinceRepository
    {
        public ProvinceRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
