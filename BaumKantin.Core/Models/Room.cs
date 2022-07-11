namespace BaumKantin.Core
{
    public class Room:BaseEntity
    {
        public string? Number { get; set; }
        public string? Floor { get; set; }
        public List<Customer>? Customers { get; set; }
    }
}
