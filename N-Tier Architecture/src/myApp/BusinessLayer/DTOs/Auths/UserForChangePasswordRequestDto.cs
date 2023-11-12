using Core.Application.Dtos;

namespace BusinessLayer.DTOs.Auths;

public class UserForChangePasswordRequestDto : IDto
{
    public string Email { get; set; }
    public string PasswordResetKey { get; set; }
    public string NewPassword { get; set; }
    public string RepeatPassword { get; set; }
}
