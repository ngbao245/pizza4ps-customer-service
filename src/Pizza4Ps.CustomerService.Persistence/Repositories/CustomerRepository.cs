using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using Pizza4Ps.CustomerService.Domain.Entities;

namespace Pizza4Ps.CustomerService.Persistence.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer, Guid>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
