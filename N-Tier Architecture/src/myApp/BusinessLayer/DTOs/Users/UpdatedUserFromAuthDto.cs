using Core.Application.Dtos;
using Core.Security.Jwt;

namespace BusinessLayer.DTOs.Users;

public class UpdatedUserFromAuthDto : IDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public AccessToken AccessToken { get; set; }
}
