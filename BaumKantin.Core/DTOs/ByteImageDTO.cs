namespace BaumKantin.Core.DTOs
{
    public class ByteImageDTO : BaseDTO
    {
        public byte[] Image { get; set; }
        public int CustomerId { get; set; }
    }
}
