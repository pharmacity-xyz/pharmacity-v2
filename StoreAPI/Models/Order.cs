using System.ComponentModel.DataAnnotations;

namespace StoreAPI.Models
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }

        public Guid UserId { get; set; }
        public virtual User? User { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        [Required]
        public string ShipAddress { get; set; } = default!;

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public DateTime ShippedDate { get; set; }

        public List<OrderItem>? OrderItems { get; set; }

        public string StatusOrder { get; set; } = default!;
    }
}
