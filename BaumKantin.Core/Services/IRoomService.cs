using BaumKantin.Core.DTOs;
using BaumKantin.Service;

namespace BaumKantin.Core.Services
{
    public interface IRoomService:IService<Room>
    {
        Task<CustomResponseDTO<List<CustomerDTO>>> GetRoomCustomersAsync(int roomId);
    }
}
