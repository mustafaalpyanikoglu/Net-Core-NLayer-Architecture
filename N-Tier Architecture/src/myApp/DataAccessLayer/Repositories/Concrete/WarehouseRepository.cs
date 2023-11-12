using Core.Persistence.Repositories;
using EntitiesLayer.Concrete;
using Persistence.Contexts;
using DataAccessLayer.Repositories.Abstract;

namespace DataAccessLayer.Repositories.Concrete;

public class WarehouseRepository : EfRepositoryBase<Warehouse, BaseDbContext>, IWarehouseRepository
{
    public WarehouseRepository(BaseDbContext context)
        : base(context) { }
}
