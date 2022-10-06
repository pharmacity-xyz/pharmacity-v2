using DataAccess.DTO;

namespace Repositories
{
    public interface IProductImageRepository
    {
        void AddNewProductImage(ProductImageDTO p);
        ProductImageDTO GetProductImage(Guid? productId);
        void UpdateProductImage(ProductImageDTO p);
        void DeleteProductImage(Guid id);
    }
}

