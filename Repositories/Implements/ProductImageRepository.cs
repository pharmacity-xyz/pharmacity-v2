using BusinessObjects.Model;
using DataAccess;
using DataAccess.DTO;
using DataAccess.Util;

namespace Repositories.Implements
{
    public class ProductImageRepository : IProductImageRepository
    {
        public void AddNewProductImage(ProductImageDTO p, Guid? productId)
        {
            Product product = ProductDAO.Instance.FindProductById(productId);
            ProductImage newProduct = new ProductImage
            {
                ProductImageId = product.ProductId,
                Image = p.Image,
                Caption = p.Caption
            };
            ProductImageDAO.Instance.AddNewProductImage(newProduct);
        }

        public ProductImageDTO GetProductImage(Guid? productId)
        {
            ProductImage productImage = ProductImageDAO.Instance.GetProductImage(productId);
            return ProductImageMapper.mapToDTO(productImage);
        }

        public void UpdateProductImage(ProductImageDTO p)
        {
            ProductImage productImage = ProductImageDAO.Instance.GetProductImage(p.ProductImageId);
            ProductImageDAO.Instance.UpdateProductImage(productImage);
        }

        public void DeleteProductImage(Guid id)
        {
            ProductImageDAO.Instance.DeleteProductImage(id);
        }

    }
}