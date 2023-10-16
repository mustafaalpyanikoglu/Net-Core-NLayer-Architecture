using Entities.Concrete;

namespace Core.Utilities.Security.Jwt;

public interface ITokenHelper
{
    // ilgili kulanıcının claim lerini içeren bir token üretecek
    AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
}
