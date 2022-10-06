namespace DataAccess.DTO
{
    public class ProductImageDTO
    {
        public Guid? ProductImageId { get; set; }
        public byte[]? Image { get; set; }
        public string? Caption { get; set; }

        public Guid? ProductId { get; set; }
    }
}

