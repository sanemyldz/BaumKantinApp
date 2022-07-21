using BaumKantin.Core;
using BaumKantin.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BaumKantin.Repository.Repositories
{
    public class RoomRepository : GenericRepository<Room>,IRoomRepository 
    {
        public RoomRepository(DataContext DataContext) : base(DataContext)
        {
        }

        public async Task<List<Room>> GetAllRooms()
        {
            var data = await _dataContext.Rooms.Include(x=>x.Customers).ToListAsync();
            return data;
        }

        public async Task<List<Customer>> GetRoomCustomersAsync(int roomId)
        {
            var room = await _dbSet.Include(x=>x.Customers).SingleOrDefaultAsync(x=>x.Id==roomId);
            return room.Customers.ToList();
        }

        public async Task<List<Customer>> GetRoomCustomersByNumberAsync(string RoomNumber)
        {
            var room = await _dbSet.Include(x => x.Customers).FirstOrDefaultAsync(x => x.Number.ToLower() == RoomNumber.ToLower());
            return room.Customers.ToList();
        }
    }
}
