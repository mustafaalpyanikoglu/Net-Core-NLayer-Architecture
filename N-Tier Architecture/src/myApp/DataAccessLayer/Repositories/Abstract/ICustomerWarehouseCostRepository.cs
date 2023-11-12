using Core.Persistence.Repositories;
using EntitiesLayer.Concrete;

namespace DataAccessLayer.Repositories.Abstract;

public interface ICustomerWarehouseCostRepository : IAsyncRepository<CustomerWarehouseCost>, IRepository<CustomerWarehouseCost>
{
}
