using DataAccess.DTO;

namespace Repositories
{
    public interface IOrderDetailRepository
    {
        OrderDetailDTO GetOrderDetailByOrderID(Guid orderID);
        void Add(OrderDetailDTO orderDetail, Guid orderId, Guid productId);
        void Update(OrderDetailDTO orderDetail);
        void Delete(Guid id);
    }
}