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
        private readonly IOrderDetailRepository orderDetailRepository;
        private readonly IProductRepository productRepository;

        public OrderController(
            IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository,
            IProductRepository productRepository
        )
        {
            this.orderRepository = orderRepository;
            this.orderDetailRepository = orderDetailRepository;
            this.productRepository = productRepository;
        }

        [HttpPost("add")]
        public IActionResult Add(OrderDTO newOrder)
        {
            try
            {
                newOrder.ShippedDate = DateTime.UtcNow;
                Guid orderId = orderRepository.Add(newOrder);
                orderDetailRepository.Add(newOrder.OrderDetail!, orderId);

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
                foreach (OrderDTO orderDTO in orderList)
                {
                    orderDTO.OrderDetail = orderDetailRepository.GetOrderDetailByOrderID(orderDTO.OrderId);
                }
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

                OrderDTO orderDTO = orderRepository.GetOrderById(id);
                orderDTO.OrderDetail = orderDetailRepository.GetOrderDetailByOrderID(orderDTO.OrderId);

                return Ok(orderDTO);
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
                foreach (OrderDTO orderDTO in orderList)
                {
                    orderDTO.OrderDetail = orderDetailRepository.GetOrderDetailByOrderID(orderDTO.OrderId);
                }
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
                orderDetailRepository.Delete(id);
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
