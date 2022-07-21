using BaumKantin.Core.DTOs;

namespace BaumKantin.Core.Services
{
    public interface IRoomService
    {
        Task<CustomResponseDTO<List<CustomerDTO>>> GetRoomCustomersAsync(int roomId);
        Task<CustomResponseDTO<List<RoomCustomersDTO>>> GetAllRooms();
        Task<CustomResponseDTO<RoomDTO>> AddRoom(RoomDTO roomDTO);
        Task<CustomResponseDTO<UpdateRoomDTO>> UpdateRoomAsync(UpdateRoomDTO updateRoomDTO);
        Task<CustomResponseDTO<NoContentResponseDTO>> RemoveRoomAsync(int Id);
        Task<CustomResponseDTO<RoomDTO>> GetByIdAsync(int Id);
        Task<CustomResponseDTO<List<CustomerDTO>>> GetRoomCustomersByNumberAsync(string RoomNumber);
    }
}
