using BusinessLayer.DTOs;
using Core.Application.Dtos;

namespace BusinessLayer.DTOs.Auths;

public class ForgotPasswordEmailAuthenticatorRequestDto : IDto
{
    public string Email { get; set; }
}
