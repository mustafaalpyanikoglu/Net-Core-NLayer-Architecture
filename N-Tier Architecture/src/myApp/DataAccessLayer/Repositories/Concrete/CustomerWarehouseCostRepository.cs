using Core.Persistence.Repositories;
using EntitiesLayer.Concrete;
using Persistence.Contexts;
using DataAccessLayer.Repositories.Abstract;

namespace DataAccessLayer.Repositories.Concrete;

public class CustomerWarehouseCostRepository : EfRepositoryBase<CustomerWarehouseCost, BaseDbContext>, ICustomerWarehouseCostRepository
{
    public CustomerWarehouseCostRepository(BaseDbContext context)
        : base(context) { }
}
