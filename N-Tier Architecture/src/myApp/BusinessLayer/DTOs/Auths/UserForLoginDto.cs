using BusinessLayer.DTOs;
using Core.Application.Dtos;

namespace BusinessLayer.DTOs.Auths;

public class UserForLoginDto : IDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}
