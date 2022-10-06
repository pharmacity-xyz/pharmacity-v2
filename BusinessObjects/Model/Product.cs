using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Model
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDetail { get; set; }
        public int UnitInStock { get; set; }
        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        public ProductImage? ProductImage { get; set; }

        public Order? Order { get; set; }
    }
}
