using BaumKantin.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaumKantin.Core.Repositories
{
    public interface ICustomerRepository:IGenericRepository<Customer>
    {
        Task<List<Room>> GetCustomerRooms(int id);
    }
}
