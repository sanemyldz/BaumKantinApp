
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
        public UserType UserTypeEnum;
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public List<Room>? Rooms { get; set; }
    }
}
