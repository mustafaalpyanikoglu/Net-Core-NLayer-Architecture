using Core.Repositories;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfRepositoryBase<User, BaseDbContext>, IUserDal
    {
        public EfUserDal(BaseDbContext context) : base(context)
        {
        }
    }
}
