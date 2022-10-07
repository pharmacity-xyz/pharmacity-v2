using DataAccess;
using DataAccess.DTO;
using DataAccess.Util;
using BusinessObjects.Model;

namespace Repositories.Implements
{
    public class OrderRepository : IOrderRepository
    {
        public void Add(OrderDTO orderDTO)
        {
            Order newOrder = new Order
            {
                OrderId = Guid.NewGuid(),
                Amount = orderDTO.Amount,
                ShipAddress = orderDTO.ShipAddress,
                OrderDate = orderDTO.OrderDate,
                ShippedDate = orderDTO.ShippedDate,
                UserId = orderDTO.UserId,
            };
            OrderDAO.Instance.Add(newOrder);
        }

        public IEnumerable<OrderDTO> GetAllOrders()
        {
            return OrderDAO.Instance.GetAllOrders().Select(p => OrderMapper.mapToDTO(p)).ToList();
        }

        public IEnumerable<OrderDTO> GetAllOrdersByUserId(Guid id)
        {
            return OrderDAO.Instance.SearchByUserId(id).Select(p => OrderMapper.mapToDTO(p)).ToList();
        }

        public OrderDTO GetOrderById(Guid id)
        {
            return OrderMapper.mapToDTO(OrderDAO.Instance.GetById(id));
        }

        public void Update(OrderDTO orderDTO)
        {
            Order order = OrderDAO.Instance.GetById(orderDTO.OrderId);
            Order tempOrder = new Order
            {
                OrderId = order.OrderId,
                Amount = orderDTO.Amount,
                ShipAddress = orderDTO.ShipAddress,
                OrderDate = orderDTO.OrderDate,
                ShippedDate = orderDTO.ShippedDate,
                UserId = orderDTO.UserId,
            };
            OrderDAO.Instance.Update(tempOrder);
        }

        public void Delete(Guid id)
        {
            OrderDAO.Instance.Delete(id);
        }
    }
}
