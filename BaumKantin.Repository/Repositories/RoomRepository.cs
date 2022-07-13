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

        public async Task<List<Customer>> GetRoomCustomersAsync(int roomId)
        {
            var room = await _dbSet.Include(x=>x.Customers).FirstOrDefaultAsync(x => x.Id == roomId);
            return room.Customers.ToList();
        }
    }
}
