using BaumKantin.Core.DTOs;
using BaumKantin.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BaumKantin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : CustomBaseController
    {
        private readonly IImageService _ImageService;

        public ImageController(IImageService imageService)
        {
            _ImageService = imageService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddImage(UpdateImageDTO imageDTO)
        {
            return CreateActionResult(await _ImageService.AddImage(imageDTO));
        }
    
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateImage(FormFileImageDTO ImageDTO)
        {
            return CreateActionResult(await _ImageService.UpdateImage(ImageDTO));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> RemoveImage(int ImageId)
        {
            return CreateActionResult(await _ImageService.RemoveImage(ImageId));
        }
    }
}
