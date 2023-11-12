using Core.Persistence.Repositories;
using EntitiesLayer.Concrete;

namespace DataAccessLayer.Repositories.Abstract;

public interface ICustomerRepository : IAsyncRepository<Customer>, IRepository<Customer>
{
}
