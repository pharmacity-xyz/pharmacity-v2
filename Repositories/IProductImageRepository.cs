using DataAccess.DTO;

namespace Repositories
{
    public interface IProductImageRepository
    {
        void AddNewProductImage(ProductImageDTO p, Guid? productId);
        ProductImageDTO GetProductImage(Guid? productId);
        void UpdateProductImage(ProductImageDTO p);
        void DeleteProductImage(Guid id);
    }
}

