using StoreAPI.DTO;
using StoreAPI.Models;
namespace StoreAPI.Services
{
    public interface IOrderService
    {
        Guid Add(OrderDTO order);
        IEnumerable<OrderDTO> GetAllOrders();
        IEnumerable<OrderDTO> GetAllOrdersByUserId(Guid id);
        OrderDTO GetOrderById(Guid id);
        void Update(OrderDTO order);
        void Delete(Guid id);
    }
}
