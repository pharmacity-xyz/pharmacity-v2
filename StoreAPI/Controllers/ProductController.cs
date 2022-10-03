using BusinessObjects.Models;
using DataAccess.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using StoreAPI.Storage;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        private readonly IOrderRepository orderRepository;
        private readonly IOrderDetailRepository orderDetailRepository;

        public ProductController(IProductRepository productRepository, IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository)
        {
            this.productRepository = productRepository;
            this.orderRepository = orderRepository;
            this.orderDetailRepository = orderDetailRepository;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                //MemberDTO member = LoggedUser.Instance.User;

                //if (member == null)
                //{
                //    throw new Exception("Can't do this action");
                //}
                return Ok(productRepository.GetProducts());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetId(int id)
        {
            try
            {
                return Ok(productRepository.GetProductById(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetByCategory/{id}")]
        public IActionResult GetCategoryId(int id)
        {
            try
            {
                return Ok(productRepository.GetProductsByCategory(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost("Add")]
        public IActionResult Add(ProductDTO product)
        {
            try
            {
                MemberDTO member = LoggedUser.Instance.User;

                if (member == null || member.Role != Role.ADMIN.ToString())
                {
                    throw new Exception("Can't do this action");
                }
                productRepository.SaveProduct(product);

                return Ok("SUCCESS");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut("Update")]
        public IActionResult Update(ProductDTO product)
        {
            try
            {
                MemberDTO member = LoggedUser.Instance.User;

                if (member == null || member.Role != Role.ADMIN.ToString())
                {
                    throw new Exception("Can't do this action");
                }
                productRepository.UpdateProduct(product);
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
                MemberDTO member = LoggedUser.Instance.User;

                if (member == null || member.Role != Role.ADMIN.ToString())
                {
                    throw new Exception("Can't do this action");
                }
                productRepository.DeleteProduct(id);

                IEnumerable<OrderDTO> orderList = orderRepository.GetAllOrders();

                foreach (OrderDTO order in orderList)
                {
                    order.OrderDetail = orderDetailRepository.GetOrderDetailByOrderID(order.OrderId);
                    if(order.OrderDetail == null)
                    {
                        orderRepository.Delete(order.OrderId);
                    }
                }

                return Ok("SUCCESS");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
