namespace BaumKantin.Core.DTOs
{
    public class CustomerDTO
    {
        public UserType UserTypeEnum { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Phone { get; set; }        
    }
}
