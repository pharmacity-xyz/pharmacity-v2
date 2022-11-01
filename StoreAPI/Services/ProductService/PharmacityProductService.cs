using StoreAPI.Models;
using StoreAPI.DTO;
using StoreAPI.Utils;

namespace StoreAPI.Services
{
    public class PharmacityProductService : IProductService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PharmacityProductService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<Product>> CreateProduct(Product product)
        {
            _context.Products!.Add(product);
            await _context.SaveChangesAsync();
            return new ServiceResponse<Product> { Data = product };
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products!.Include(p => p.Images).ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<Product>> GetProductAsync(Guid productId)
        {
            var response = new ServiceResponse<Product>();
            Product? product = null;

            product = await _context.Products!
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.ProductId == productId);

            if (product == null)
            {
                response.Success = false;
                response.Message = "Sorry, but this product does not exist.";
            }
            else
            {
                response.Data = product;
            }

            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsByCategory(Guid categoryId)
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products!
                    .Where(p => p.CategoryId == categoryId)
                    .Include(p => p.Images)
                    .ToListAsync(),
            };

            return response;
        }

        public async Task<ServiceResponse<ProductSearchResult>> SearchProducts(string searchText, int page)
        {
            var pageResults = 2f;
            var pageCount = Math.Ceiling((await FindProductsBySearchText(searchText)).Count / pageResults);
            var products = await _context.Products!
                                .Where(p => p.ProductName.ToLower().Contains(searchText.ToLower()) ||
                                    p.ProductDescription.ToLower().Contains(searchText.ToLower()))
                                .Include(p => p.Images)
                                .Skip((page - 1) * (int)pageResults)
                                .Take((int)pageResults)
                                .ToListAsync();

            var response = new ServiceResponse<ProductSearchResult>
            {
                Data = new ProductSearchResult
                {
                    Products = products,
                    CurrentPage = page,
                    Pages = (int)pageCount
                }
            };

            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetFeaturedProducts()
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products!
                        .Where(p => p.Featured)
                        .Include(p => p.Images)
                        .ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<Product>> UpdateProduct(Product product)
        {
            var dbProduct = await _context.Products!
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.ProductId == product.ProductId);

            if (dbProduct == null)
            {
                return new ServiceResponse<Product>
                {
                    Success = false,
                    Message = "Product not found."
                };
            }

            dbProduct.ProductName = product.ProductName;
            dbProduct.ProductDescription = product.ProductDescription;
            dbProduct.ImageUrl = product.ImageUrl;
            dbProduct.CategoryId = product.CategoryId;
            dbProduct.Featured = product.Featured;

            var productImages = dbProduct.Images;
            _context.ProductImages!.RemoveRange(productImages);

            dbProduct.Images = product.Images;

            await _context.SaveChangesAsync();
            return new ServiceResponse<Product> { Data = product };
        }

        public async Task<ServiceResponse<bool>> DeleteProduct(Guid productId)
        {
            var dbProduct = await _context.Products!.FindAsync(productId);
            if (dbProduct == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Product not found."
                };
            }

            _context.Products.Remove(dbProduct);
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };

        }

        private async Task<List<Product>> FindProductsBySearchText(string searchText)
        {
            return await _context.Products!
                .Where(p => p.ProductName.ToLower().Contains(searchText.ToLower()) ||
                        p.ProductDescription.ToLower().Contains(searchText.ToLower()))
                .ToListAsync();
        }
    }
}
