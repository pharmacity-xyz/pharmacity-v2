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
        // private readonly IOrderDetailRepository orderDetailRepository;

        public ProductController(
            IProductRepository productRepository,
            IOrderRepository orderRepository
        )
        {
            this.productRepository = productRepository;
            this.orderRepository = orderRepository;
            // this.orderDetailRepository = orderDetailRepository;
        }

        [HttpGet("get_all")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(productRepository.GetProducts());
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
                return Ok(productRepository.GetProductById(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("get_by_category/{id}")]
        public IActionResult GetCategoryId(Guid id)
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

        [HttpPost("add")]
        public IActionResult Add(ProductDTO product)
        {
            try
            {
                UserDTO user = LoggedUser.Instance!.User!;

                if (user == null)
                {
                    throw new Exception("Can not find the user");
                }
                else if (user.Role != Role.ADMIN.ToString())
                {
                    throw new Exception("Please login with admin");
                }

                productRepository.SaveProduct(product);

                return Ok("Successfully added");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut("update")]
        public IActionResult Update(ProductDTO product)
        {
            try
            {
                UserDTO user = LoggedUser.Instance!.User!;

                if (user == null)
                {
                    throw new Exception("Can not find the user");
                }
                else if (user.Role != Role.ADMIN.ToString())
                {
                    throw new Exception("Please login with admin");
                }

                productRepository.UpdateProduct(product);
                return Ok("Successfully updated");
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
                UserDTO user = LoggedUser.Instance!.User!;

                if (user == null)
                {
                    throw new Exception("Can not find the user");
                }
                else if (user.Role != Role.ADMIN.ToString())
                {
                    throw new Exception("Please login with admin");
                }

                productRepository.DeleteProduct(id);

                IEnumerable<OrderDTO> orderList = orderRepository.GetAllOrders();

                return Ok("Successfully deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
