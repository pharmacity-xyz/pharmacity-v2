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

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public OrderDetailDTO GetOrderDetailByOrderID(Guid orderID)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderDetailDTO orderDetail)
        {
            throw new NotImplementedException();
        }
    }
}