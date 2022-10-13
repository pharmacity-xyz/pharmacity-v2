using System.ComponentModel.DataAnnotations;
using StoreAPI.Models;

namespace StoreAPI.DTO
{
    public class ProductDTO
    {
        public Guid? ProductId { get; set; }

        [Required]
        public string ProductName { get; set; } = string.Empty;

        [Required]
        public string ProductDescription { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public List<ProductImage> Images { get; set; } = new List<ProductImage>();

        [Required]
        public int Stock { get; set; }

        [Required]
        public decimal Price { get; set; }

        public bool Featured { get; set; } = false;

        public Guid CategoryId { get; set; }

        public ProductImageDTO? ProductImage { get; set; }
    }
}
