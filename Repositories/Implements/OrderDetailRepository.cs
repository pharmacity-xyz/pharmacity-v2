using DataAccess;
using DataAccess.DTO;
using DataAccess.Util;
using BusinessObjects.Model;

namespace Repositories.Implements
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public void Add(OrderDetailDTO orderDetailDTO)
        {
            OrderDetail newOrderDetail = new OrderDetail
            {
                OrderDetailId = Guid.NewGuid(),
                Price = orderDetailDTO.Price,
                Quantity = orderDetailDTO.Quantity,
                OrderId = orderDetailDTO.OrderId,
                ProductId = orderDetailDTO.ProductId,
            };
            OrderDetailDAO.Instance.Add(newOrderDetail);
        }

        public OrderDetailDTO GetOrderDetailByOrderID(Guid orderID)
        {
            return OrderDetailMapper.mapToDTO(OrderDetailDAO.Instance.GetById(orderID));
        }

        public void Update(OrderDetailDTO orderDetailDTO)
        {
            OrderDetail orderDetail = OrderDetailDAO.Instance.GetById(orderDetailDTO.OrderDetailId);
            OrderDetail newOrderDetail = new OrderDetail
            {
                OrderDetailId = orderDetail.OrderDetailId,
                Price = orderDetailDTO.Price,
                Quantity = orderDetailDTO.Quantity,
                OrderId = orderDetailDTO.OrderId,
                ProductId = orderDetailDTO.ProductId,
            };
            OrderDetailDAO.Instance.Update(newOrderDetail);
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}