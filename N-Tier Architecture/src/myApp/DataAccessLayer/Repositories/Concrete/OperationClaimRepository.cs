using Core.Persistence.Repositories;
using DataAccessLayer.Repositories.Abstract;
using EntitiesLayer.Concrete;
using Persistence.Contexts;

namespace DataAccessLayer.Repositories.Concrete;

public class OperationClaimRepository : EfRepositoryBase<OperationClaim, BaseDbContext>, IOperationClaimRepository
{
    public OperationClaimRepository(BaseDbContext context)
        : base(context) { }
}
