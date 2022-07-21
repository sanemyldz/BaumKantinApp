using AutoMapper;
using BaumKantin.Core;
using BaumKantin.Core.DTOs;
using BaumKantin.Core.Repositories;
using BaumKantin.Core.Services;
using BaumKantin.Core.UnitOfWorks;
using BaumKantin.Repository;

namespace BaumKantin.Service.Services
{
    public class RoomService:IRoomService
    {
        private readonly IMapper _mapper;
        private readonly IRoomRepository _roomRepository;
        private readonly IGenericRepository<Room> _genericRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RoomService(IMapper mapper, IRoomRepository roomRepository, IGenericRepository<Room> genericRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _roomRepository = roomRepository;
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomResponseDTO<RoomDTO>> AddRoom(RoomDTO roomDTO)
        {
            await _genericRepository.AddAsync(_mapper.Map<Room>(roomDTO));
            await _unitOfWork.CommitAsync();
            return CustomResponseDTO<RoomDTO>.Success(200, roomDTO);
        }

        public async Task<CustomResponseDTO<List<RoomCustomersDTO>>> GetAllRooms()
        {
            var room = await _roomRepository.GetAllRooms();
            var roomDto=_mapper.Map<List<RoomCustomersDTO>>(room);
            return CustomResponseDTO<List<RoomCustomersDTO>>.Success(200, roomDto);
        }

        public async Task<CustomResponseDTO<List<CustomerDTO>>> GetRoomCustomersAsync(int roomId)
        {
            var customers =await _roomRepository.GetRoomCustomersAsync(roomId);
            var customerDto= _mapper.Map<List<CustomerDTO>>(customers);
            return CustomResponseDTO<List<CustomerDTO>>.Success(200,customerDto);
        }

        public async Task<CustomResponseDTO<RoomDTO>> GetByIdAsync(int Id)
        {
            var room = await _genericRepository.GetByIdAsync(Id);
            var roomDTO = _mapper.Map<RoomDTO>(room);
            return CustomResponseDTO<RoomDTO>.Success(200, roomDTO);
        }

        public async Task<CustomResponseDTO<List<CustomerDTO>>> GetRoomCustomersByNumberAsync(string RoomNumber)
        {
            var customers = await _roomRepository.GetRoomCustomersByNumberAsync(RoomNumber.ToLower());
            var customerDto = _mapper.Map<List<CustomerDTO>>(customers);
            return CustomResponseDTO<List<CustomerDTO>>.Success(200, customerDto);
        }

        public async Task<CustomResponseDTO<NoContentResponseDTO>> RemoveRoomAsync(int Id)
        {
            var room = await _genericRepository.GetByIdAsync(Id);
            _genericRepository.Remove(room);
            await _unitOfWork.CommitAsync();
            return CustomResponseDTO<NoContentResponseDTO>.Success(204);
        }

        public async Task<CustomResponseDTO<UpdateRoomDTO>> UpdateRoomAsync(UpdateRoomDTO updateRoomDTO)
        {
            _genericRepository.Update(_mapper.Map<Room>(updateRoomDTO));
            await _unitOfWork.CommitAsync();
            return CustomResponseDTO<UpdateRoomDTO>.Success(200, updateRoomDTO);
        }

    }
}
