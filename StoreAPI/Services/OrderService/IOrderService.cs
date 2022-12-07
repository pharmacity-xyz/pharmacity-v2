using StoreAPI.Utils;
using StoreAPI.Models;

namespace StoreAPI.Services
{
    public interface IOrderService
    {
        Task<ServiceResponse<bool>> PlaceOrder(Guid userId, string shipAddress);
        Task<ServiceResponse<List<OrderOverviewResponse>>> GetOrders();
        Task<ServiceResponse<OrderDetailsResponse>> GetOrderDetails(Guid orderId);
        Task<ServiceResponse<List<OrderOverviewResponse>>> GetOrdersForAdmin();
        Task<ServiceResponse<uint[]>> GetOrdersPerMonth(uint year, uint month);
        Task<ServiceResponse<OrderByCategoryResponse>> GetOrdersForPieChart();
        Task<ServiceResponse<OrderDetailsResponse>> UpdateStatusOrder(Guid orderId, string statusOrder);
    }
}
