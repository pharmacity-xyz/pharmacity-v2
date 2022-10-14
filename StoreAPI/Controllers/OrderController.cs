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

        [HttpGet("{orderId}")]
        public async Task<ActionResult<ServiceResponse<OrderDetailsResponse>>> GetOrderDetails(Guid orderId)
        {

            var response = await _orderService.GetOrders();
            return Ok(response);

        }
    }
}
