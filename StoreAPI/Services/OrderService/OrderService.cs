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

        public async Task<ServiceResponse<OrderDetailsResponse>> GetOrderDetails(Guid orderId)
        {
            var response = new ServiceResponse<OrderDetailsResponse>();
            var order = await _context.Orders!
                .Include(o => o.OrderItems!)
                .ThenInclude(oi => oi.Product)
                .Include(o => o.OrderItems)
                .Where(o => o.UserId == _authService.GetUserId() && o.OrderId == orderId)
                .OrderByDescending(o => o.OrderDate)
                .FirstOrDefaultAsync();

            if (order == null)
            {
                response.Success = false;
                response.Message = "Order not found.";
                return response;
            }

            var orderDetailsResponse = new OrderDetailsResponse
            {
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                Products = new List<OrderDetailsProductResponse>()
            };

            order.OrderItems!.ForEach(item =>
                orderDetailsResponse.Products.Add(new OrderDetailsProductResponse
                {
                    ProductId = item.ProductId,
                    ImageUrl = item.Product!.ImageUrl,
                    Quantity = item.Quantity,
                    ProductName = item.Product.ProductName,
                    TotalPrice = item.TotalPrice,
                })
            );

            response.Data = orderDetailsResponse;

            return response;
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
