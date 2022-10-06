using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Model
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }

        [Required]
        public DateTime? OrderedDate { get; set; }

        [Required]
        public DateTime? ShipDate { get; set; }

        public Guid UserId { get; set; }
        public virtual User? User { get; set; }

        public List<Product>? Products { get; set; }
    }
}
