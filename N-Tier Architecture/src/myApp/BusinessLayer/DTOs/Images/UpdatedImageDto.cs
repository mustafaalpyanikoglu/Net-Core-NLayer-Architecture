using Core.Application.Dtos;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer.DTOs.Images
{
    public class UpdatedImageDto : IDto
    {
        public IFormFile Image { get; set; }
        public string ImageUrl { get; set; }
    }
}
