using DataAccess;
using DataAccess.DTO;
using DataAccess.Util;

namespace Repositories.Implements
{
    public class OrderRepository : IOrderRepository
    {
        public void Add(OrderDTO order)
        {
            OrderDAO.Instance.Add(Mapper.mapToEntity(order));
        }

        public IEnumerable<OrderDTO> GetAllOrders()
        {
            return OrderDAO.Instance.GetList().Select(p => Mapper.mapToDTO(p)).ToList();
        }

        public IEnumerable<OrderDTO> GetAllOrdersByUserId(Guid id)
        {
            return OrderDAO.Instance.SearchByUserId(id).Select(p => Mapper.mapToDTO(p)).ToList();
        }

        public OrderDTO GetOrderById(Guid id)
        {
            return Mapper.mapToDTO(OrderDAO.Instance.GetById(id));
        }

        public void Update(OrderDTO order)
        {
            OrderDAO.Instance.Update(Mapper.mapToEntity(order));
        }

        public void Delete(Guid id)
        {
            OrderDAO.Instance.Delete(id);
        }
    }
}
