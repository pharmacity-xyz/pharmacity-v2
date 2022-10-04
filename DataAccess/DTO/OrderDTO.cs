using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public DateTime? OrderedDate { get; set; }
        public DateTime? ShipDate { get; set; }

        public int? UserId { get; set; }
    }
}
