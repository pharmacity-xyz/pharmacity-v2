using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
