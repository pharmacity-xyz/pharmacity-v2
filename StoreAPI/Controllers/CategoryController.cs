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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IOrderRepository orderRepository;

        public CategoryController(
            ICategoryRepository categoryRepository,
            IOrderRepository orderRepository
        )
        {
            this.categoryRepository = categoryRepository;
            this.orderRepository = orderRepository;
        }

        [HttpPost("add")]
        public IActionResult Add(CategoryDTO category)
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

                categoryRepository.Add(category);

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
            return Ok(categoryRepository.GetCategory());
        }

        [HttpPut("update")]
        public IActionResult Update(CategoryDTO category)
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

                categoryRepository.Update(category);

                return Ok("Successfully updated");
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
                categoryRepository.Delete(id);
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
