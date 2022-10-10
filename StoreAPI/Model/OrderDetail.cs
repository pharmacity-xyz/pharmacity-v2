using System.ComponentModel.DataAnnotations;

namespace StoreAPI.Model
{
    public class OrderDetail
    {
        [Key]
        public Guid OrderDetailId { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public Guid OrderId { get; set; }
        public virtual Order? Order { get; set; }

        public Guid ProductId { get; set; }
        public virtual Product? Product { get; set; }
    }
}