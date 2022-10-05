using BusinessObjects.Model;
using DataAccess;
using DataAccess.DTO;
using DataAccess.Util;

namespace Repositories.Implements
{
    public class ProductRepository : IProductRepository
    {
        public void SaveProduct(ProductDTO p)
        {
            ProductDAO.Instance.SaveProduct(Mapper.mapToEntity(p));
        }

        public ProductDTO GetProductById(Guid id)
        {
            return Mapper.mapToDTO(ProductDAO.Instance.FindProductById(id));
        }

        public List<ProductDTO> GetProducts()
        {
            return ProductDAO.Instance.GetProducts().Select(p => Mapper.mapToDTO(p)).ToList();
        }

        public List<ProductDTO> GetProductsByCategory(Guid id)
        {
            return ProductDAO.Instance.FindProductByCategoryId(id).Select(p => Mapper.mapToDTO(p)).ToList();
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
