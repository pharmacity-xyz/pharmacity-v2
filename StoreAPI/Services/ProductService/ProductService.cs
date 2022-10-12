using StoreAPI.Models;
using StoreAPI.DTO;
using StoreAPI.Utils;

namespace StoreAPI.Services
{
    public class ProductService : IProductService
    {

        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductService(DataContext context, IHttpContextAccessor httpContextAccessor)
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

        public ProductDTO AddNewProduct(ProductDTO productDTO)
        {
            // Product new_product = new Product
            // {
            //     ProductId = Guid.NewGuid(),
            //     ProductName = productDTO.ProductName,
            //     ProductDescription = productDTO.ProductDescription,
            //     Price = productDTO.Price,
            //     Stock = productDTO.Stock,
            //     CategoryId = productDTO.CategoryId
            // };
            // ProductDAO.Instance.SaveProduct(new_product);
            // return ProductMapper.mapToDTO(new_product);
            throw new NotImplementedException();
        }

        public ProductDTO GetProductById(Guid id)
        {
            // return ProductMapper.mapToDTO(ProductDAO.Instance.FindProductById(id));
            throw new NotImplementedException();
        }

        public List<ProductDTO> GetProducts()
        {
            // return ProductDAO.Instance.GetProducts().Select(p => ProductMapper.mapToDTO(p)).ToList();
            throw new NotImplementedException();
        }

        public List<ProductDTO> GetProductsByCategory(Guid id)
        {
            // return ProductDAO.Instance.FindProductByCategoryId(id).Select(p => ProductMapper.mapToDTO(p)).ToList();

            throw new NotImplementedException();
        }

        public void UpdateProduct(ProductDTO productDTO)
        {
            // Product product = ProductDAO.Instance.FindProductById(productDTO.ProductId);
            // Product updatedProduct = new Product
            // {
            //     ProductId = product.ProductId,
            //     ProductName = productDTO.ProductName,
            //     ProductDescription = productDTO.ProductDescription,
            //     Price = productDTO.Price,
            //     Stock = productDTO.Stock,
            //     CategoryId = productDTO.CategoryId
            // };
            // ProductDAO.Instance.UpdateProduct(updatedProduct);
            throw new NotImplementedException();
        }

        public void DeleteProduct(Guid id)
        {
            // ProductDAO.Instance.DeleteProduct(id);
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Product>> GetProductAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Product>>> GetProductsByCategory(string categoryUrl)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<ProductSearchResult>> SearchProducts(string searchText, int page)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Product>>> GetFeaturedProducts()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Product>>> GetAdminProducts()
        {
            throw new NotImplementedException();
        }



        public Task<ServiceResponse<Product>> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool>> DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
