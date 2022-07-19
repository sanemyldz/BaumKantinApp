using BaumKantin.Core.DTOs;
using BaumKantin.Repository;

namespace BaumKantin.Core.Repositories
{
    public interface ICustomerRepository:IGenericRepository<Customer>
    {
        Task<List<Room>> GetCustomerRooms(int id);
        Task<List<Customer>> GetDataAsync();
    }
}
