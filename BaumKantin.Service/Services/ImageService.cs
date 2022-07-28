using AutoMapper;
using BaumKantin.Core;
using BaumKantin.Core.DTOs;
using BaumKantin.Core.Models;
using BaumKantin.Core.Repositories;
using BaumKantin.Core.Services;
using BaumKantin.Core.UnitOfWorks;

namespace BaumKantin.Service.Services
{
    public class ImageService :  IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _UnitofWork;

        public ImageService(IImageRepository imageRepository, IMapper mapper, 
             IUnitOfWork unitofWork)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
            _UnitofWork = unitofWork;
        }

        public async Task<CustomResponseDTO<UpdateImageDTO>> AddImage(UpdateImageDTO ImageDTO)
        {
            var newImage = new ImageModel();
            newImage.Image= TypeConverter.ImageConvert(ImageDTO.Image);
            newImage.CustomerId = ImageDTO.CustomerId;
            
            /*TODO
             * Mapping operations amoung byte[] and FormFile will be handled.
             * Error occurs when new attiributes added in ImageModel.
             */

            //var image=_mapper.Map<ImageModel>(byteImageDTO);
            await _imageRepository.AddAsync(newImage);
            await _UnitofWork.CommitAsync();
            return CustomResponseDTO<UpdateImageDTO>.Success(200, ImageDTO);
        }

        public async Task<CustomResponseDTO<NoContentResponseDTO>> RemoveImage(int ImageId)
        {
            var imageEntity= await _imageRepository.GetByIdAsync(ImageId);
            _imageRepository.Remove(imageEntity);
            await _UnitofWork.CommitAsync();
            return CustomResponseDTO<NoContentResponseDTO>.Success(200);
        }

        public async Task<CustomResponseDTO<FormFileImageDTO>> UpdateImage(FormFileImageDTO ImageDTO)
        {
            ImageModel image=new ImageModel();
            image.Image = TypeConverter.ImageConvert(ImageDTO.Image);
            image.CustomerId = ImageDTO.CustomerId;
            _imageRepository.Update(image);
            await _UnitofWork.CommitAsync();
            return CustomResponseDTO<FormFileImageDTO>.Success(200,ImageDTO);
        }
    }
}
