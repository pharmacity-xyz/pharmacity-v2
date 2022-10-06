using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Model
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime? OrderedDate { get; set; }
        public DateTime? ShipDate { get; set; }

        public Guid UserId { get; set; }
        public virtual User? User { get; set; }

        public List<Product>? Products { get; set; }
    }
}
