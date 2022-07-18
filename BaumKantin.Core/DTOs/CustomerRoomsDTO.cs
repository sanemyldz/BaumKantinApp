using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaumKantin.Core.DTOs
{
    public class CustomerRoomsDTO
    {
        public int? IdentityId { get; set; }
        public UserType UserTypeEnum;
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Phone { get; set; }
        public ICollection<RoomDTO>? Rooms { get; set; }
    }
}
