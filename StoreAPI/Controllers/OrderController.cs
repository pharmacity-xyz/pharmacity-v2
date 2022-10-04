using DataAccess.DTO;
using Microsoft.AspNetCore.Http;
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

        public OrderController(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IProductRepository productRepository)
        {
            this.orderRepository = orderRepository;
            this.orderDetailRepository = orderDetailRepository;
            this.productRepository = productRepository;
        }

        [HttpGet("get_all")]
        public IActionResult GetAll()
        {
            try
            {
                IEnumerable<OrderDTO> orderList = orderRepository.GetAllOrders();
                foreach (OrderDTO order in orderList)
                {
                    order.OrderDetail = orderDetailRepository.GetOrderDetailByOrderID(order.OrderId);
                }
                return Ok(orderList);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("get_by_id/{id}")]
        public IActionResult GetId(int id)
        {

            try
            {
                UserDTO user = LoggedUser.Instance!.User!;

                if (user == null)
                {
                    throw new Exception("Can not find the user");
                }

                OrderDTO order = orderRepository.GetOrderById(id);
                order.OrderDetail = orderDetailRepository.GetOrderDetailByOrderID(order.OrderId);
                return Ok(order);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("get_all_by_userid/{userid}")]
        public IActionResult GetAll(int userid)
        {
            try
            {
                UserDTO user = LoggedUser.Instance!.User!;

                if (user == null)
                {
                    throw new Exception("Can not find the user");
                }

                IEnumerable<OrderDTO> orderList = orderRepository.GetAllOrdersByUserId(userid);
                foreach (OrderDTO order in orderList)
                {
                    order.OrderDetail = orderDetailRepository.GetOrderDetailByOrderID(order.OrderId);
                    // order.OrderDetail.CategoryId = productRepository.GetProductById((int)order.OrderDetail.ProductId!).CategoryId;
                }
                return Ok(orderList);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("add")]
        public IActionResult Add(OrderDTO newOrder)
        {
            try
            {
                ProductDTO orderProduct = productRepository.GetProductById((int)newOrder.OrderDetail!.ProductId!);

                if (orderProduct.UnitsInStock < newOrder.OrderDetail.Quantity)
                {
                    throw new Exception("Units in stock of " + orderProduct.ProductName + " not enough");
                }

                newOrder.OrderedDate = DateTime.Now;
                newOrder.OrderDetail.ProductName = orderProduct.ProductName;
                newOrder.OrderDetail.Price = orderProduct.Price;

                orderProduct.UnitsInStock -= (int)newOrder.OrderDetail.Quantity!;

                productRepository.UpdateProduct(orderProduct);
                orderRepository.Add(newOrder);

                return Ok("Successfully added");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
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
