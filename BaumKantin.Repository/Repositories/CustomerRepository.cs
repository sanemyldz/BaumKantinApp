using BaumKantin.Core;
using BaumKantin.Core.DTOs;
using BaumKantin.Core.Repositories;
using BaumKantin.Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace BaumKantin.Repository.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly IGenericRepository<Customer> _genericRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly object _mapper;

        public CustomerRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<List<Room>> GetCustomerRooms(int id)
        {
            var customer = await _dbSet.Include(x => x.Rooms).FirstOrDefaultAsync(x => x.Id == id);
            return customer.Rooms.ToList();
        }

        public async Task<List<Customer>> GetDataAsync()
        {
            var data = await _dataContext.Customers.Include(x => x.Rooms).ToListAsync();
            return data;
        }
    }
}
