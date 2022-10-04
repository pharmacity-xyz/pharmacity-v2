using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Model
{
    public class OrderDetail
    {
        public int? OrderDetailId { get; set; }
        public int? ProductId { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }

        public int OrderForeignKey { get; set; }
        public Order? Order { get; set; }

        public virtual Product? Product { get; set; }
    }
}
