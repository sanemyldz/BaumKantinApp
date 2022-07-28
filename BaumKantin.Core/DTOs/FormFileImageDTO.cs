using Microsoft.AspNetCore.Http;

namespace BaumKantin.Core.DTOs
{
    public class FormFileImageDTO:BaseDTO
    {
        public IFormFile Image { get; set; }
        public int CustomerId { get; set; }
    }
}
