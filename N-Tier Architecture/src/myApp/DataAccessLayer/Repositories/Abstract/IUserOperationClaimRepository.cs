using Core.Persistence.Repositories;
using EntitiesLayer.Concrete;

namespace DataAccessLayer.Repositories.Abstract;

public interface IUserOperationClaimRepository : IAsyncRepository<UserOperationClaim>, IRepository<UserOperationClaim> { }
