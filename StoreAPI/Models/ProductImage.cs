namespace StoreAPI.Models
{
    public class ProductImage
    {
        public Guid ProductImageId { get; set; }
        public string Data { get; set; } = string.Empty;
        public string Caption { get; set; } = string.Empty;
    }
}

