namespace DataAccess.DTO
{
    public class ProductImageDTO
    {
        public Guid? ProductImageId { get; set; }
        public byte[] Image { get; set; } = default!;
        public string? Caption { get; set; }
    }
}

