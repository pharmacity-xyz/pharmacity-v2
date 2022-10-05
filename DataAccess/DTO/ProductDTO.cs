namespace DataAccess.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int UnitsInStock { get; set; }
        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }
    }
}
