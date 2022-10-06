using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Model
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }

        [Required]
        public float Amount { get; set; }

        [Required]
        public string ShipAddress { get; set; } = default!;

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public DateTime ShippedDate { get; set; }

        public Guid UserId { get; set; }
        public virtual User? User { get; set; }

        public List<Product>? Products { get; set; }
    }
}
