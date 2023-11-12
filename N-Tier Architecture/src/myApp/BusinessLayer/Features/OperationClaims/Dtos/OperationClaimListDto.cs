using Core.Application.Dtos;

namespace BusinessLayer.Features.OperationClaims.Dtos;

public class OperationClaimListDto : IDto
{
    public string Name { get; set; }
    public string Description { get; set; }
}
