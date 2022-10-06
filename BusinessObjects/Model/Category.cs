using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Model
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
    }
}
