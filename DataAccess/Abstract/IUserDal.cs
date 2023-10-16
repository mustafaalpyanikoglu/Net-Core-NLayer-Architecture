using Core.Repositories;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserDal : IRepository<User>, IAsyncRepository<User>
    {
    }
}
