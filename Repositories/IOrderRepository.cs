using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IOrderRepository
    {
        void Add(OrderDTO order);
        IEnumerable<OrderDTO> GetAllOrders();
        IEnumerable<OrderDTO> GetAllOrdersByUserId(Guid id);
        OrderDTO GetOrderById(Guid id);
        void Update(OrderDTO order);
        void Delete(Guid id);
    }
}
