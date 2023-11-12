using BusinessLayer.DTOs;
using Core.Application.Dtos;

namespace BusinessLayer.DTOs.Auths;

public class RevokedTokenDto : IDto
{
    public int Id { get; set; }
    public string Token { get; set; }
}