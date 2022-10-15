using System.ComponentModel.DataAnnotations;

namespace StoreAPI.Models
{
    public class OrderItem
    {
        public Guid OrderId { get; set; }
        public virtual Order? Order { get; set; }

        public Guid ProductId { get; set; }
        public virtual Product? Product { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }
    }
}