using DataAccess.DTO;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using StoreAPI.Storage;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository orderRepository;
        private readonly IProductRepository productRepository;

        public OrderController(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
        }

        [HttpPost("add")]
        public IActionResult Add(OrderDTO newOrder)
        {
            try
            {
                newOrder.OrderDate = DateTime.UtcNow;
                newOrder.ShippedDate = DateTime.UtcNow;
                orderRepository.Add(newOrder);

                return Ok("Successfully added");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("get_all")]
        public IActionResult GetAll()
        {
            try
            {
                IEnumerable<OrderDTO> orderList = orderRepository.GetAllOrders();
                return Ok(orderList);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("get_by_id/{id}")]
        public IActionResult GetId(Guid id)
        {

            try
            {
                UserDTO user = LoggedUser.Instance!.User!;

                if (user == null)
                {
                    throw new Exception("Please login");
                }

                OrderDTO order = orderRepository.GetOrderById(id);
                return Ok(order);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("get_all_by_userid/{userid}")]
        public IActionResult GetAll(Guid userid)
        {
            try
            {
                UserDTO user = LoggedUser.Instance!.User!;

                if (user == null)
                {
                    throw new Exception("Please login");
                }

                IEnumerable<OrderDTO> orderList = orderRepository.GetAllOrdersByUserId(userid);
                return Ok(orderList);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                orderRepository.Delete(id);
                return Ok("Successfully deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
