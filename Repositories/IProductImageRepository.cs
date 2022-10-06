using DataAccess.DTO;

namespace Repositories
{
    public interface IProductImageRepository
    {
        void AddNewProductImage(ProductImageDTO p);
        ProductImageDTO GetProductImage(Guid id);
        void UpdateProductImage(ProductImageDTO p);
        void DeleteProductImage(Guid id);
    }
}

