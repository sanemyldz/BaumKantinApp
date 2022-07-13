using AutoMapper;
using BaumKantin.Core;
using BaumKantin.Core.DTOs;
using BaumKantin.Core.Services;
using BaumKantin.Service;
using Microsoft.AspNetCore.Mvc;

namespace BaumKantin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : CustomBaseController
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public RoomController(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetRoomCustomers(int roomId)
        {
            return CreateActionResult(await _roomService.GetRoomCustomersAsync(roomId));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var room = await _roomService.GetAllAsync();
            var roomDto = _mapper.Map<List<RoomDTO>>(room);
            return CreateActionResult(CustomResponseDTO<List<RoomDTO>>.Success(200, roomDto));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetById(int roomId)
        {
            var room = await _roomService.GetByIdAsync(roomId);
            var roomDto = _mapper.Map<RoomDTO>(room);
            return CreateActionResult(CustomResponseDTO<RoomDTO>.Success(200, roomDto));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Add(RoomDTO roomDTO)
        {
           var room = await _roomService.AddAsync(_mapper.Map<Room>(roomDTO));
            var roomDto=_mapper.Map<RoomDTO>(room);
            return CreateActionResult(CustomResponseDTO<RoomDTO>.Success(200,roomDto));
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(RoomDTO roomDTO)
        {
            await _roomService.UpdateAsync(_mapper.Map<Room>(roomDTO));
            return CreateActionResult(CustomResponseDTO<NoContentResponseDTO>.Success(200));
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> Remove(int id)
        {
            var room=await _roomService.GetByIdAsync(id);
            await _roomService.RemoveAsync(room);
            return CreateActionResult(CustomResponseDTO<NoContentResponseDTO>.Success(200));
        }

    }
}
