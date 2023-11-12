using BusinessLayer.Features.UserOperationClaims.Dtos;
using Core.Persistence.Paging;

namespace BusinessLayer.Features.UserOperationClaims.Models;

public class UserOperationClaimListModel : BasePageableModel
{
    public IList<UserOperationClaimListDto> Items { get; set; }
}
