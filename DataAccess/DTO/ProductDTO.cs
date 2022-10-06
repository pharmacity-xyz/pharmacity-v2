namespace DataAccess.DTO
{
    public class ProductDTO
    {
        public Guid? ProductId { get; set; }
        public string ProductName { get; set; } = default!;
        public string ProductDetail { get; set; } = default!;
        public int UnitsInStock { get; set; }
        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }

        public ProductImageDTO? ProductImage { get; set; }
    }
}
