using Core.Persistence.Repositories;
using DataAccessLayer.Repositories.Abstract;
using EntitiesLayer.Concrete;
using Persistence.Contexts;

namespace DataAccessLayer.Repositories.Concrete;

public class UserRepository : EfRepositoryBase<User, BaseDbContext>, IUserRepository
{
    public UserRepository(BaseDbContext context)
        : base(context) { }
}
