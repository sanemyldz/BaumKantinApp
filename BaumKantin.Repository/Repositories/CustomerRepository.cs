using BaumKantin.Core;
using BaumKantin.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BaumKantin.Repository.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository 
    {
        public CustomerRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<Room> GetCustomerRoom(int id)
        {
            var customer = await _dbSet.Include(x=>x.Room).FirstOrDefaultAsync(x => x.Id == id);
            return customer.Room;
        }     
    }
}
