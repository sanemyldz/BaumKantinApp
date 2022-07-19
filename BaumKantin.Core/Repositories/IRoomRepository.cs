using BaumKantin.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaumKantin.Core.Repositories
{
    public interface IRoomRepository:IGenericRepository<Room>
    {
        Task<List<Customer>> GetRoomCustomersAsync(int roomId);
        Task<List<Room>> GetDataAsync();
    }
}
