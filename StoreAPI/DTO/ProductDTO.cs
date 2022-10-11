namespace StoreAPI.DTO
{
    public class ProductDTO
    {
        public Guid? ProductId { get; set; }
        public string ProductName { get; set; } = default!;
        public string ProductDescription { get; set; } = default!;
        public int Stock { get; set; }
        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }

        public ProductImageDTO? ProductImage { get; set; }
    }
}
