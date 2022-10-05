using BusinessObjects.Model;
using DataAccess;
using DataAccess.DTO;
using DataAccess.Util;

namespace Repositories.Implements
{
    public class ProductRepository : IProductRepository
    {
        public void SaveProduct(ProductDTO productDTO)
        {
            Product new_product = new Product
            {
                ProductId = Guid.NewGuid(),
                ProductName = productDTO.ProductName,
                Price = productDTO.Price,
                UnitInStock = productDTO.UnitsInStock,
                CategoryId = productDTO.CategoryId
            };
            ProductDAO.Instance.SaveProduct(new_product);
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

        public void UpdateProduct(ProductDTO p)
        {
            ProductDAO.Instance.UpdateProduct(Mapper.mapToEntity(p));
        }

        public void DeleteProduct(Guid id)
        {
            ProductDAO.Instance.DeleteProduct(id);
        }
    }
}
