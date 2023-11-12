using Core.Application.Dtos;

namespace BusinessLayer.Features.OperationClaims.Dtos;

public class OperationClaimDto : IDto
{
    public string Name { get; set; }
    public string Description { get; set; }
}
