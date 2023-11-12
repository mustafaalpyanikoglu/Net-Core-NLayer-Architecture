using BusinessLayer.DTOs;
using Core.Application.Dtos;

namespace BusinessLayer.DTOs.Auths;

public class EnableEmailAuthenticatorRequestDto : IDto
{
    public string Email { get; set; }
}
