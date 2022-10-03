using DataAccess;
using DataAccess.DTO;
using DataAccess.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implements
{
    public class OrderRepository : IOrderRepository
    {
        public void Add(OrderDTO order)
        {
            OrderDAO.Instance.Add(Mapper.mapToEntity(order));
        }

        public void Delete(int id)
        {
            OrderDAO.Instance.Delete(id);
        }

        public IEnumerable<OrderDTO> GetAllOrders()
        {
            return OrderDAO.Instance.GetList().Select(p => Mapper.mapToDTO(p)).ToList();
        }

        public IEnumerable<OrderDTO> GetAllOrdersByUserId(int id)
        {
            return OrderDAO.Instance.SearchByUserId(id).Select(p => Mapper.mapToDTO(p)).ToList();
        }

        public OrderDTO GetOrderById(int id)
        {
            return Mapper.mapToDTO(OrderDAO.Instance.GetById(id));
        }

        public void Update(OrderDTO order)
        {
            OrderDAO.Instance.Update(Mapper.mapToEntity(order));
        }
    }
}
