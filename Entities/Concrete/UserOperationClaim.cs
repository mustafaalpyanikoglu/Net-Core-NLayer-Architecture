using Core.Repositories;

namespace Entities.Concrete;

public class UserOperationClaim : Entity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }

    public UserOperationClaim()
    {
        
    }

    public UserOperationClaim(int id, int userId, int operationClaimId):this()
    {
        Id = id;
        UserId = userId;
        OperationClaimId = operationClaimId;
    }
}