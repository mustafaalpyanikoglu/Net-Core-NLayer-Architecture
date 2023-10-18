using Core.Persistence.Repositories;
using EntitiesLayer.Concrete;

namespace DataAccessLayer.Repositories.Abstract;

public interface IOperationClaimRepository : IAsyncRepository<OperationClaim>, IRepository<OperationClaim> { }
