using StoreAPI.DTO;
using StoreAPI.Models;
using StoreAPI.Utils;

namespace StoreAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;
        private readonly ICartService _cartService;
        private readonly IAuthService _authService;

        public OrderService(DataContext context, ICartService cartService, IAuthService authService)
        {
            _context = context;
            _cartService = cartService;
            _authService = authService;
        }

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
