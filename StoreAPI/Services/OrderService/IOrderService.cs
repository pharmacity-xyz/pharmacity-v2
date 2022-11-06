using StoreAPI.Utils;

namespace StoreAPI.Services
{
    public interface IOrderService
    {
        Task<ServiceResponse<bool>> PlaceOrder(Guid userId);
        Task<ServiceResponse<List<OrderOverviewResponse>>> GetOrders();
        Task<ServiceResponse<OrderDetailsResponse>> GetOrderDetails(Guid orderId);
        Task<ServiceResponse<List<OrderOverviewResponse>>> GetOrdersForAdmin();
    }
}
