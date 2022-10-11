using Microsoft.AspNetCore.Mvc;

using StoreAPI.Models;
using DataAccess.DTO;
// using Repositories;
using StoreAPI.Services;

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

        [HttpPost("add")]
        public IActionResult Add(ProductDTO product)
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

                // ProductDTO newProductDTO = productRepository.AddNewProduct(product);
                // productImageRepository.AddNewProductImage(product.ProductImage!, newProductDTO.ProductId);

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
                IEnumerable<ProductDTO> productList = _productService.GetProducts();
                // foreach (ProductDTO productDTO in productList)
                // {
                //     productDTO.ProductImage = productImage.GetProductImage(productDTO.ProductId);
                // }
                return Ok(productList);
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
                return Ok(_productService.GetProductById(id));
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
