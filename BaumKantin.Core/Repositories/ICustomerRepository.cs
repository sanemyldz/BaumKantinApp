using BaumKantin.Repository;

namespace BaumKantin.Core.Repositories
{
    public interface ICustomerRepository:IGenericRepository<Customer>
    {
        Task<Room> GetCustomerRoom(int id);
    }
}
