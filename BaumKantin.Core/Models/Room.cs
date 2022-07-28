using System.ComponentModel.DataAnnotations;

namespace BaumKantin.Core
{
    public class Room:BaseEntity
    {
        [Required]
        public string Number { get; set; }
        
        [Required]
        public string Floor { get; set; }

        public virtual ICollection<Customer>? Customers { get; set; }
    }
}
