using Core.Application.Dtos;

namespace BusinessLayer.Features.Users.Dtos;

public class DeletedUserDto : IDto
{
    public int Id { get; set; }
}
