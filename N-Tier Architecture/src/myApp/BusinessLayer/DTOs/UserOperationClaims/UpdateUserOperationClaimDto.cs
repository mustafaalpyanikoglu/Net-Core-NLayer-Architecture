using Core.Application.Dtos;

namespace BusinessLayer.DTOs.UserOperationClaims;

public class UpdateUserOperationClaimDto : IDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }
}
