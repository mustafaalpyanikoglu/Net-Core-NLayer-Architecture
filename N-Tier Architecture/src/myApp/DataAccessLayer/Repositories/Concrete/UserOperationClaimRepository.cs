using Core.Persistence.Repositories;
using DataAccessLayer.Repositories.Abstract;
using EntitiesLayer.Concrete;
using Persistence.Contexts;

namespace DataAccessLayer.Repositories.Concrete;

public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, BaseDbContext>, IUserOperationClaimRepository
{
    public UserOperationClaimRepository(BaseDbContext context)
        : base(context) { }
}
