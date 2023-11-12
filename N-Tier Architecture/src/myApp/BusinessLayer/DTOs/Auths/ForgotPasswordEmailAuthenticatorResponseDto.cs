using BusinessLayer.DTOs;
using Core.Application.Dtos;

namespace BusinessLayer.DTOs.Auths;

public class ForgotPasswordEmailAuthenticatorResponseDto : IDto
{
    public int UserId { get; set; }
    public string PasswordResetKey { get; set; }
}
