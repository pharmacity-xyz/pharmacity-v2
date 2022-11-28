using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using StoreAPI.Utils;
using StoreAPI.Services;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<OrderOverviewResponse>>>> GetOrders()
        {
            var response = await _orderService.GetOrders();
            return Ok(response);
        }

        [HttpGet("orderid/{orderId}")]
        public async Task<ActionResult<ServiceResponse<OrderDetailsResponse>>> GetOrderDetails(Guid orderId)
        {
            var response = await _orderService.GetOrderDetails(orderId);
            return Ok(response);
        }

        [HttpGet("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<OrderOverviewResponse>>>> GetOrdersForAdmin()
        {
            var response = await _orderService.GetOrdersForAdmin();
            return Ok(response);
        }

        [HttpGet("charts"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<uint[]>>> GetOrdersPerMonth(uint year, uint month)
        {
            var response = await _orderService.GetOrdersPerMonth(year, month);
            return Ok(response);
        }
    }
}
