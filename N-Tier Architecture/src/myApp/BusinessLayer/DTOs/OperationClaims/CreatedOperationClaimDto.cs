using Core.Application.Dtos;

namespace BusinessLayer.DTOs.OperationClaims;

public class CreatedOperationClaimDto : IDto
{
    public string Name { get; set; }
    public string Description { get; set; }
}
