using BusinessLayer.Features.OperationClaims.Dtos;
using Core.Persistence.Paging;

namespace BusinessLayer.Features.OperationClaims.Models;

public class OperationClaimListModel : BasePageableModel
{
    public IList<OperationClaimListDto> Items { get; set; }
}
