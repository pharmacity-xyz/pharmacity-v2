using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using StoreAPI.Models;
using StoreAPI.DTO;
using StoreAPI.Services;
using StoreAPI.Utils;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IOrderService _orderService;

        public CategoryController(
            ICategoryService categoryService,
            IOrderService orderService
        )
        {
            _categoryService = categoryService;
            _orderService = orderService;
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Category>>>> AddCategory(CategoryDTO category)
        {
            var result = await _categoryService.AddCategory(
                new Category
                {
                    CategoryId = Guid.NewGuid(),
                    Name = category.CategoryName
                }
            );
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Category>>>> GetCategories()
        {
            var result = await _categoryService.GetCategories();
            return Ok(result);
        }

        [HttpPut, Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Category>>>> UpdateCategory(Category category)
        {
            var result = await _categoryService.UpdateCategory(category);
            return Ok(result);
        }

        [HttpDelete("/{id}"), Authorize(Roles = "Admin")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _categoryService.Delete(id);
                // IEnumerable<OrderDTO> orderList = _orderService.GetAllOrders();
                return Ok("Successfully deleted");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
