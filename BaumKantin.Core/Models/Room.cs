namespace BaumKantin.Core
{
    public class Room:BaseEntity
    {
        public string? Number { get; set; }
        public string? Floor { get; set; }
        public virtual ICollection<Customer>? Customers { get; set; }
    }
}
