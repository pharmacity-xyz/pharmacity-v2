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

        [HttpGet("GetAllOrder")]
        public IActionResult GetAll()
        {
            try
            {
                //MemberDTO member = LoggedUser.Instance.User;

                //if (member == null)
                //{
                //    throw new Exception("Can't do this action");
                //}

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

        [HttpGet("GetOrder/{id}")]
        public IActionResult GetId(int id)
        {

            try
            {
                UserDTO user = LoggedUser.Instance.User;

                if (user == null)
                {
                    throw new Exception("Can't do this action");
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

        [HttpGet("GetAllMemberOrder/{userid}")]
        public IActionResult GetAll(int userid)
        {
            try
            {
                UserDTO user = LoggedUser.Instance.User;

                if (user == null)
                {
                    throw new Exception("Can't do this action");
                }

                IEnumerable<OrderDTO> orderList = orderRepository.GetAllOrdersByUserId(userid);
                foreach (OrderDTO order in orderList)
                {
                    order.OrderDetail = orderDetailRepository.GetOrderDetailByOrderID(order.OrderId);
                    order.OrderDetail.CategoryId = productRepository.GetProductById((int)order.OrderDetail.ProductId!).CategoryId;
                }
                return Ok(orderList);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("AddOrder")]
        public IActionResult Add(
            OrderDTO newOrder
        )
        {

            try
            {
                //memberdto member = loggeduser.instance.user;

                //if (member == null)
                //{
                //    throw new exception("can't do this action");
                //}

                ProductDTO orderProduct = productRepository.GetProductById((int)newOrder.OrderDetail.ProductId);

                if (orderProduct.UnitsInStock < newOrder.OrderDetail.Quantity)
                {
                    throw new Exception("Units in stock of " + orderProduct.ProductName + " not enough");
                }

                newOrder.OrderDate = DateTime.Now;
                newOrder.OrderDetail.ProductName = orderProduct.ProductName;
                newOrder.OrderDetail.UnitPrice = orderProduct.UnitPrice;

                orderProduct.UnitsInStock -= (int)newOrder.OrderDetail.Quantity!;

                productRepository.UpdateProduct(orderProduct);
                orderRepository.Add(newOrder);

                return Ok("SUCCESS");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                //MemberDTO member = LoggedUser.Instance.User;

                //if (member == null || member.Role != Role.ADMIN.ToString())
                //{
                //    throw new Exception("Can't do this action");
                //}
                orderDetailRepository.Delete(id);
                orderRepository.Delete(id);
                return Ok("SUCCESS");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
