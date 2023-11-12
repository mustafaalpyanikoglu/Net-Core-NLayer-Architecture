using Core.Persistence.Repositories;
using DataAccessLayer.Repositories.Abstract;
using EntitiesLayer.Concrete;
using Persistence.Contexts;

namespace DataAccessLayer.Repositories.Concrete;

public class RefreshTokenRepository : EfRepositoryBase<RefreshToken, BaseDbContext>, IRefreshTokenRepository
{
    public RefreshTokenRepository(BaseDbContext context)
        : base(context) { }
}
