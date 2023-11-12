using Core.Persistence.Repositories;
using EntitiesLayer.Concrete;
using Persistence.Contexts;
using DataAccessLayer.Repositories.Abstract;

namespace DataAccessLayer.Repositories.Concrete;

public class CustomerRepository : EfRepositoryBase<Customer, BaseDbContext>, ICustomerRepository
{
    public CustomerRepository(BaseDbContext context)
        : base(context) { }
}
