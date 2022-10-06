using BusinessObjects.Model;
using DataAccess;
using DataAccess.DTO;
using DataAccess.Util;

namespace Repositories.Implements
{
    public class ProductRepository : IProductRepository
    {
        public ProductDTO AddNewProduct(ProductDTO productDTO)
        {
            Product new_product = new Product
            {
                ProductId = Guid.NewGuid(),
                ProductName = productDTO.ProductName,
                ProductDetail = productDTO.ProductDetail,
                Price = productDTO.Price,
                UnitInStock = productDTO.UnitsInStock,
                CategoryId = productDTO.CategoryId
            };
            ProductDAO.Instance.SaveProduct(new_product);
            return ProductMapper.mapToDTO(new_product);
        }

        public ProductDTO GetProductById(Guid id)
        {
            return ProductMapper.mapToDTO(ProductDAO.Instance.FindProductById(id));
        }

        public List<ProductDTO> GetProducts()
        {
            return ProductDAO.Instance.GetProducts().Select(p => ProductMapper.mapToDTO(p)).ToList();
        }

        public List<ProductDTO> GetProductsByCategory(Guid id)
        {
            return ProductDAO.Instance.FindProductByCategoryId(id).Select(p => ProductMapper.mapToDTO(p)).ToList();
        }

        public void UpdateProduct(ProductDTO productDTO)
        {
            Product product = ProductDAO.Instance.FindProductById(productDTO.ProductId);
            ProductDAO.Instance.UpdateProduct(product);
        }

        public void DeleteProduct(Guid id)
        {
            ProductDAO.Instance.DeleteProduct(id);
        }
    }
}
