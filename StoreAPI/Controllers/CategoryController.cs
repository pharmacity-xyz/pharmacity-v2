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
        private readonly IOrderDetailRepository orderDetailRepository;

        public CategoryController(
            ICategoryRepository categoryRepository,
            IOrderDetailRepository orderDetailRepository,
            IOrderRepository orderRepository
        )
        {
            this.categoryRepository = categoryRepository;
            this.orderDetailRepository = orderDetailRepository;
            this.orderRepository = orderRepository;
        }

        [HttpGet("get_all")]
        public IActionResult GetAll()
        {
            return Ok(categoryRepository.GetCategory());
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
                    throw new Exception("Please login with admin account");
                }

                categoryRepository.Add(category);

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
                categoryRepository.Delete(id);

                IEnumerable<OrderDTO> orderList = orderRepository.GetAllOrders();
                foreach (OrderDTO order in orderList)
                {
                    order.OrderDetail = orderDetailRepository.GetOrderDetailByOrderID(order.OrderId);
                    if (order.OrderDetail == null)
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

        [HttpPut("update")]
        public IActionResult Update(CategoryDTO category)
        {
            try
            {
                UserDTO user = LoggedUser.Instance!.User!;

                if (user == null || user.Role != Role.ADMIN.ToString())
                {
                    throw new Exception("Can't do this action");
                }

                categoryRepository.Update(category);

                return Ok("Success");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
