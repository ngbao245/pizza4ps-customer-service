using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using Pizza4Ps.CustomerService.Domain.Entities;

namespace Pizza4Ps.CustomerService.Persistence.Repositories
{
    public class DistrictRepository : RepositoryBase<District, Guid>, IDistrictRepository
    {
        public DistrictRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
