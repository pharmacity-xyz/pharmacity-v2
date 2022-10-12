using System.ComponentModel.DataAnnotations;

namespace StoreAPI.Models
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }
        [Required]
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public List<ProductImage> Images { get; set; } = new List<ProductImage>();
        [Required]
        public int Stock { get; set; }

        [Required]
        public decimal Price { get; set; }

        public virtual Category? Category { get; set; }
        public Guid CategoryId { get; set; }
    }
}
