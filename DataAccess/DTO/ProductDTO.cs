namespace DataAccess.DTO
{
    public class ProductDTO
    {
        public Guid? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDetail { get; set; }
        public int UnitsInStock { get; set; }
        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }

        public ProductImageDTO? ProductImageDTO { get; set; }
    }
}
