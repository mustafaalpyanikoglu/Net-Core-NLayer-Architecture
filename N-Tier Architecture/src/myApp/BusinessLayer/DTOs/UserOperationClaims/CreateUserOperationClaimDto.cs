using Core.Application.Dtos;

namespace BusinessLayer.DTOs.UserOperationClaims;

public class CreateUserOperationClaimDto : IDto
{
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }
}
