using Core.Application.Dtos;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer.DTOs.Images
{
    public class CreatedImageDto : IDto
    {
        public int UserID { get; set; }
        public IFormFile Image { get; set; }
    }
}
