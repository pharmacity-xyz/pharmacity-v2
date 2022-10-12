using System.ComponentModel.DataAnnotations;

namespace StoreAPI.Models
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public List<ProductImage> Images { get; set; } = new List<ProductImage>();
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public bool Featured { get; set; }

        public virtual Category? Category { get; set; }
        public Guid CategoryId { get; set; }
    }
}
