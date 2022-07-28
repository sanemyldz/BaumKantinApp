using BaumKantin.Core.DTOs;

namespace BaumKantin.Core.Services
{
    public interface IImageService
    {
        Task<CustomResponseDTO<UpdateImageDTO>> AddImage(UpdateImageDTO imageDTO);
        Task<CustomResponseDTO<NoContentResponseDTO>> RemoveImage(int ImageId);
        Task<CustomResponseDTO<FormFileImageDTO>> UpdateImage(FormFileImageDTO ImageDTO);
    }
}
