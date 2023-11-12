using Core.Application.Dtos;
using Core.Security.Jwt;
using EntitiesLayer.Concrete;

namespace BusinessLayer.Features.Auths.Dtos;

public class RefreshedTokensDto : IDto
{
    public AccessToken AccessToken { get; set; }
    public RefreshToken RefreshToken { get; set; }
}