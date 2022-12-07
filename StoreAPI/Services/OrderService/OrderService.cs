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
                StatusOrder = order.StatusOrder,
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

        public async Task<ServiceResponse<List<OrderOverviewResponse>>> GetOrders()
        {
            var response = new ServiceResponse<List<OrderOverviewResponse>>();
            var orders = await _context.Orders!
                .Include(o => o.OrderItems!)
                .ThenInclude(oi => oi.Product)
                .Where(o => o.UserId == _authService.GetUserId())
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();

            var orderResponse = new List<OrderOverviewResponse>();
            orders.ForEach(o => orderResponse.Add(new OrderOverviewResponse
            {
                Id = o.OrderId,
                OrderDate = o.OrderDate,
                TotalPrice = o.TotalPrice,
                StatusOrder = o.StatusOrder,
                Product = o.OrderItems!.Count > 1 ?
                    $"{o.OrderItems.First().Product!.ProductName} and" +
                    $" {o.OrderItems.Count - 1} more..." :
                    o.OrderItems.First().Product!.ProductName,
                ProductImageUrl = o.OrderItems.First().Product!.ImageUrl
            }));

            response.Data = orderResponse;

            return response;
        }

        public async Task<ServiceResponse<List<OrderOverviewResponse>>> GetOrdersForAdmin()
        {
            var response = new ServiceResponse<List<OrderOverviewResponse>>();
            var orders = await _context.Orders!
                .Include(o => o.OrderItems!)
                .ThenInclude(oi => oi.Product)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();

            var orderResponse = new List<OrderOverviewResponse>();
            orders.ForEach(o => orderResponse.Add(new OrderOverviewResponse
            {
                Id = o.OrderId,
                OrderDate = o.OrderDate,
                StatusOrder = o.StatusOrder,
                TotalPrice = o.TotalPrice,
                Product = o.OrderItems!.Count > 1 ?
                    $"{o.OrderItems.First().Product!.ProductName} and" +
                    $" {o.OrderItems.Count - 1} more..." :
                    o.OrderItems.First().Product!.ProductName,
                ProductImageUrl = o.OrderItems.First().Product!.ImageUrl
            }));

            response.Data = orderResponse;

            return response;
        }

        public async Task<ServiceResponse<OrderByCategoryResponse>> GetOrdersForPieChart()
        {
            var response = new ServiceResponse<OrderByCategoryResponse>();
            var orders = await _context.Orders!
                            .Include(o => o.OrderItems!)
                            .ThenInclude(oi => oi.Product)
                            .OrderByDescending(o => o.OrderDate)
                            .ToListAsync();

            var categories = await _context.Categories!.ToListAsync();

            var labelList = new List<string>();
            var colorsList = new List<string>();
            var numbersList = new List<int>();
            numbersList.AddRange(Enumerable.Repeat(0, categories.Count));

            categories.ForEach(c =>
            {
                labelList.Add(c.Name);
                Random rnd = new Random();
                colorsList.Add($"rgb({rnd.Next(0, 255)}, {rnd.Next(0, 255)}, {rnd.Next(0, 255)})");
            });

            orders.ForEach(o =>
            {
                for (int i = 0; i < labelList.Count; i++)
                {
                    if (labelList[i] == o.OrderItems!.First().Product!.Category!.Name)
                    {
                        numbersList[i] += 1;
                    }
                }
            });

            var orderByCategoryRes = new OrderByCategoryResponse
            {
                Labels = labelList,
                Colors = colorsList,
                Numbers = numbersList,
            };
            response.Data = orderByCategoryRes;
            return response;
        }

        public async Task<ServiceResponse<uint[]>> GetOrdersPerMonth(uint year, uint month)
        {
            var response = new ServiceResponse<uint[]>();
            var orders = await _context.Orders!.ToListAsync();

            // Get the data of specific year, return month data
            if (year != 0 && month == 0)
            {
                uint[] orderData = new uint[12];
                orders.ForEach(o =>
                {
                    if (o.OrderDate.Year == year)
                    {
                        var month = o.OrderDate.Month;
                        orderData[month - 1] += 1;
                    }
                });
                response.Data = orderData;
            }

            // Get the data of specific month, return day data
            if (year != 0 && month != 0)
            {
                uint[] orderData = new uint[31];
                orders.ForEach(o =>
                {
                    if (o.OrderDate.Year == year && o.OrderDate.Month == month)
                    {
                        var day = o.OrderDate.Day;
                        orderData[day - 1] += 1;
                    }
                });
                response.Data = orderData;
            }

            return response;
        }

        public async Task<ServiceResponse<bool>> PlaceOrder(Guid userId, string shipAddress)
        {
            var products = (await _cartService.GetDbCartProducts(userId)).Data;
            decimal totalPrice = 0;
            products!.ForEach(product => totalPrice += product.Price * product.Quantity);

            var orderItems = new List<OrderItem>();
            products.ForEach(product => orderItems.Add(new OrderItem
            {
                ProductId = product.ProductId,
                Quantity = product.Quantity,
                TotalPrice = product.Price * product.Quantity
            }));

            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.UtcNow,
                TotalPrice = totalPrice,
                ShipAddress = shipAddress,
                OrderItems = orderItems,
                StatusOrder = "PAID"
            };

            _context.Orders!.Add(order);

            _context.CartItems!.RemoveRange(_context.CartItems
                .Where(ci => ci.UserId == userId));

            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true };
        }
    }
}
