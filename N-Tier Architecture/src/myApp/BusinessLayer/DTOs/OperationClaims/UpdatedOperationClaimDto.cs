using Core.Application.Dtos;

namespace BusinessLayer.DTOs.OperationClaims;

public class UpdatedOperationClaimDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
