using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Model
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }

        [Required]
        public string? ProductName { get; set; }

        [Required]
        public string? ProductDetail { get; set; }

        [Required]
        public int UnitInStock { get; set; }

        [Required]
        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        public ProductImage? ProductImage { get; set; }

        public Order? Order { get; set; }
    }
}
