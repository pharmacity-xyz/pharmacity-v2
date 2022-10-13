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
        public async Task<ActionResult<ServiceResponse<Product>>> GetProduct(Guid productId)
        {
            var response = await _productService.GetProductAsync(productId);
            return Ok(response);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsByCategory(Guid categoryId)
        {
            var response = await _productService.GetProductsByCategory(categoryId);
            return Ok(response);
        }

        [HttpGet("search/{searchText}/{page}")]
        public async Task<ActionResult<ServiceResponse<ProductSearchResult>>> SearchProducts(string searchText, int page = 1)
        {
            var response = await _productService.SearchProducts(searchText, page);
            return Ok(response);
        }

        [HttpGet("featured")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetFeaturedProducts()
        {
            var response = await _productService.GetFeaturedProducts();
            return Ok(response);
        }

        [HttpPut, Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<Product>>> UpdateProduct(Product product)
        {
            var response = await _productService.UpdateProduct(product);
            return Ok(response);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteProduct(Guid id)
        {
            var response = await _productService.DeleteProduct(id);
            return Ok(response);
        }
    }
}
