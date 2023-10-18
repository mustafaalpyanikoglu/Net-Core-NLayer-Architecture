using Core.Persistence.Repositories;
using EntitiesLayer.Concrete;

namespace DataAccessLayer.Repositories.Abstract;

public interface IUserRepository : IAsyncRepository<User>, IRepository<User>
{
}
