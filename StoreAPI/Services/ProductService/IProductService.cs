using DataAccess.DTO;

namespace StoreAPI.Services
{
    public interface IProductService
    {
        ProductDTO AddNewProduct(ProductDTO p);
        List<ProductDTO> GetProducts();
        List<ProductDTO> GetProductsByCategory(Guid id);
        ProductDTO GetProductById(Guid id);
        void UpdateProduct(ProductDTO p);
        void DeleteProduct(Guid id);
    }
}
