namespace BaumKantin.Core.DTOs
{
    public class RoomCustomersDTO:BaseDTO
    {
        public string Number { get; set; }
        public string Floor { get; set; }
        public ICollection<CustomerDTO> Customers { get; set; }
    }
}
