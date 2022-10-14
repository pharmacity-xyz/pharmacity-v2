using StoreAPI.DTO;
using StoreAPI.Models;
using StoreAPI.Utils;

namespace StoreAPI.Services
{
    public class OrderService : IOrderService
    {
        public Task<ServiceResponse<OrderDetailsResponse>> GetOrderDetails(Guid orderId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<OrderOverviewResponse>>> GetOrders()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool>> PlaceOrder(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
