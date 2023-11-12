using Core.Persistence.Repositories;
using EntitiesLayer.Concrete;
using Persistence.Contexts;
using DataAccessLayer.Repositories.Abstract;

namespace DataAccessLayer.Repositories.Concrete;

public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, BaseDbContext>, IUserOperationClaimRepository
{
    public UserOperationClaimRepository(BaseDbContext context)
        : base(context) { }
}
