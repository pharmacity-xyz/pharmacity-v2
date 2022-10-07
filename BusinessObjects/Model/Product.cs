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
        public string? ProductDescription { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        public ProductImage? ProductImage { get; set; }

        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}
