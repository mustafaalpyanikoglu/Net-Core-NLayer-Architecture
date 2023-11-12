using Core.Persistence.Repositories;
using EntitiesLayer.Concrete;

namespace DataAccessLayer.Repositories.Abstract;

public interface IWarehouseRepository : IAsyncRepository<Warehouse>, IRepository<Warehouse>
{
}
