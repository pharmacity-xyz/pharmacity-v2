using DataAccess.DTO;

namespace Repositories
{
    public interface IOrderRepository
    {
        Guid Add(OrderDTO order);
        IEnumerable<OrderDTO> GetAllOrders();
        IEnumerable<OrderDTO> GetAllOrdersByUserId(Guid id);
        OrderDTO GetOrderById(Guid id);
        void Update(OrderDTO order);
        void Delete(Guid id);
    }
}
