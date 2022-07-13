using BaumKantin.Core.DTOs;
using BaumKantin.Core.Repositories;
using BaumKantin.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaumKantin.Core.Services
{
    public interface ICustomerService : IService<Customer>
    {
        Task<CustomResponseDTO<List<RoomDTO>>> GetCustomerRooms(int id);
    }
}
