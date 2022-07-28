using Microsoft.AspNetCore.Http;

namespace BaumKantin.Core.DTOs
{
    public class UpdateImageDTO 
    {
        public IFormFile Image { get; set; }
        public int CustomerId { get; set; }
    }
}
