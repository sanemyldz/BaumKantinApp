
using BaumKantin.Core.DTOs;

namespace BaumKantin.Core
{
    public enum UserType:Byte
    {
        Admin,
        Intern,
        Worker
    }
    public class Customer: BaseEntity
    {
        public int? IdentityId { get; set; }
        public UserType UserTypeEnum { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Phone { get; set; }
        public virtual Room? Room  { get; set; }
        public int? RoomId  { get; set; }
    }
}
