using System.ComponentModel.DataAnnotations;

namespace BaumKantin.Core.Models
{
    public class ImageModel : BaseEntity
    {
        /* TODO
         * ImageName
         * Size
         * File Extention
        */

        [Required]
        public byte[] Image { get; set; }
       
        public Customer? Customer { get; set; }

        [Required]
        public int CustomerId { get; set; }
    }
}
    