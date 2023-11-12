using Core.Application.Dtos;

namespace BusinessLayer.Features.Auths.Dtos;

public class ForgotPasswordEmailAuthenticatorResponseDto : IDto
{
    public int UserId { get; set; }
    public string PasswordResetKey { get; set; }
}
