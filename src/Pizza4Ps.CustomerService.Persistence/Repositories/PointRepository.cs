using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using Pizza4Ps.CustomerService.Domain.Entities;

namespace Pizza4Ps.CustomerService.Persistence.Repositories
{
    public class PointRepository : RepositoryBase<Point, Guid>, IPointRepository
    {
        public PointRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
