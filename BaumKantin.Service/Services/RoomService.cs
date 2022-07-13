using BaumKantin.Core;
using BaumKantin.Core.DTOs;
using BaumKantin.Core.Services;
using BaumKantin.Core.UnitOfWorks;
using BaumKantin.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BaumKantin.Repository.Repositories;
using BaumKantin.Core.Repositories;

namespace BaumKantin.Service.Services
{
    public class RoomService:Service<Room>,IRoomService
    {
        private readonly IMapper _mapper;
        private readonly IRoomRepository _roomRepository;

        public RoomService(IGenericRepository<Room> genericRepository, IUnitOfWork unitOfWork, 
            IMapper mapper, IRoomRepository roomRepository) : base(genericRepository, unitOfWork)
        {
            _mapper = mapper;
            _roomRepository = roomRepository;
        }


        public async Task<CustomResponseDTO<List<CustomerDTO>>> GetRoomCustomersAsync(int roomId)
        {
            var customers =await _roomRepository.GetRoomCustomersAsync(roomId);
            var customerDto= _mapper.Map<List<CustomerDTO>>(customers);
            return CustomResponseDTO<List<CustomerDTO>>.Success(200,customerDto);
        }
    }
}
