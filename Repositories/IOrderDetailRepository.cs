using DataAccess.DTO;

namespace Repositories
{
    public interface IOrderDetailRepository
    {
        void Add(OrderDetailDTO orderDetail, Guid orderId);
        OrderDetailDTO GetOrderDetailByOrderID(Guid? orderID);
        void Update(OrderDetailDTO orderDetail);
        void Delete(Guid id);
    }
}