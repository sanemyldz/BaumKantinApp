using AutoMapper;
using BaumKantin.Core;
using BaumKantin.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BaumKantin.Repository.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly IMapper _mapper;

        public CustomerRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<List<Room>> GetCustomerRooms(int id)
        {
            var customer = await _dbSet.Include(x => x.rooms).FirstOrDefaultAsync(x => x.Id == id);
            return customer.rooms.ToList();
        }
    }
}
