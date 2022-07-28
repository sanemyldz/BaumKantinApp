using BaumKantin.Repository;

namespace BaumKantin.Core.Repositories
{
    public interface IRoomRepository:IGenericRepository<Room>
    {
        Task<List<Customer>> GetRoomCustomersAsync(int roomId);
        Task<List<Room>> GetAllRooms();
        Task<List<Customer>> GetRoomCustomersByNumberAsync(string RoomNumber);
    }
}
