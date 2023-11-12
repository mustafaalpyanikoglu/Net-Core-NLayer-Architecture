using BusinessLayer.DTOs;
using Core.Application.Dtos;

namespace BusinessLayer.DTOs.Auths;

public class EnableEmailAuthenticatorResponseDto : IDto
{
    public int UserId { get; set; }
    public string ActivationKey { get; set; }
}
