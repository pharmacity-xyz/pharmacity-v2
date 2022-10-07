using DataAccess.DTO;

namespace Repositories
{
    public interface IOrderDetailRepository
    {
        OrderDetailDTO GetOrderDetailByOrderID(Guid orderID);
        void Add(OrderDetailDTO orderDetail);
        void Update(OrderDetailDTO orderDetail);
        void Delete(Guid id);
    }
}