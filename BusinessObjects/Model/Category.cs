using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Model
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }

        [Required]
        public string Name { get; set; } = default!;

        public virtual ICollection<Product>? Products { get; set; }
    }
}
