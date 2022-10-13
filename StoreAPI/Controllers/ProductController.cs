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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<Product>>> CreateProduct(ProductDTO request)
        {
            var response = await _productService.CreateProduct(
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = request.ProductName,
                    ProductDescription = request.ProductDescription,
                    ImageUrl = request.ImageUrl,
                    Stock = request.Stock,
                    Price = request.Price,
                    Featured = request.Featured,
                    CategoryId = request.CategoryId,
                }
            );
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
        {
            var response = await _productService.GetProductsAsync();
            return Ok(response);
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetProduct(Guid id)
        {
            var response = await _productService.GetProductAsync(id);
            return Ok(response);
        }

        [HttpGet("get_by_category/{id}")]
        public IActionResult GetCategoryId(Guid id)
        {
            try
            {
                return Ok(_productService.GetProductsByCategory(id));
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
                // UserDTO user = LoggedUser.Instance!.User!;

                // if (user == null)
                // {
                //     throw new Exception("Can not find the user");
                // }
                // else if (user.Role != Role.ADMIN.ToString())
                // {
                //     throw new Exception("Please login with admin");
                // }

                // productRepository.UpdateProduct(product);
                // productImageRepository.UpdateProductImage(product.ProductImage!);
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
                // UserDTO user = LoggedUser.Instance!.User!;

                // if (user == null)
                // {
                //     throw new Exception("Can not find the user");
                // }
                // else if (user.Role != Role.ADMIN.ToString())
                // {
                //     throw new Exception("Please login with admin");
                // }

                // productRepository.DeleteProduct(id);

                // IEnumerable<OrderDTO> orderList = orderRepository.GetAllOrders();

                return Ok("Successfully deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
