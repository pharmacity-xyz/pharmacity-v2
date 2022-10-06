using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Model
{
    public class ProductImage
    {
        [Key]
        public Guid ProductImageId { get; set; }
        [Required]
        public byte[]? Image { get; set; }
        public string? Caption { get; set; }

        // public Guid? ProductId { get; set; }
        public virtual Product? Product { get; set; }
    }
}

