using BaumKantin.Core.DTOs;
using BaumKantin.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BaumKantin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : CustomBaseController
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetRoomCustomers(int roomId)
        {
            return CreateActionResult(await _roomService.GetRoomCustomersAsync(roomId));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllRooms()
        {
            return CreateActionResult(await _roomService.GetAllRooms());
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetRoomCustomersByNumberAsync(string RoomNumber)
        {
            return CreateActionResult(await _roomService.GetRoomCustomersByNumberAsync(RoomNumber));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddRoom(RoomDTO roomDTO)
        {
            return CreateActionResult(await _roomService.AddRoom(roomDTO));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetById(int roomId)
        {
            return CreateActionResult(await _roomService.GetByIdAsync(roomId));
        }
      
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(UpdateRoomDTO roomDTO)
        {
            return CreateActionResult(await _roomService.UpdateRoomAsync(roomDTO));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Remove(int Id)
        {            
            return CreateActionResult(await _roomService.RemoveRoomAsync(Id));
        }

    }
}
