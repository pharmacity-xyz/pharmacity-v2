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

        public CategoryController(ICategoryRepository categoryRepository, IOrderDetailRepository orderDetailRepository, IOrderRepository orderRepository)
        {
            this.categoryRepository = categoryRepository;
            this.orderDetailRepository = orderDetailRepository;
            this.orderRepository = orderRepository;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(categoryRepository.GetCategory());
        }

        [HttpPost("Add")]
        public IActionResult Add(CategoryDTO category)
        {
            try
            {
                MemberDTO member = LoggedUser.Instance.User;

                if (member == null || member.Role != Role.ADMIN.ToString())
                {
                    throw new Exception("Can't do this action");
                }

                categoryRepository.Add(category);

                return Ok("Success");
            }
            catch(Exception e)
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

        [HttpPut("Update")]
        public IActionResult Update(CategoryDTO category)
        {
            try
            {
                MemberDTO member = LoggedUser.Instance.User;

                if (member == null || member.Role != Role.ADMIN.ToString())
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
