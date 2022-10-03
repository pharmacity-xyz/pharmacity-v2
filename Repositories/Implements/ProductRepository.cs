using BusinessObjects.Model;
using DataAccess;
using DataAccess.DTO;
using DataAccess.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implements
{
    public class ProductRepository : IProductRepository
    {
        public void DeleteProduct(int id)
        {
            ProductDAO.Instance.DeleteProduct(id);
        }

        public ProductDTO GetProductById(int id)
        {
            return Mapper.mapToDTO(ProductDAO.Instance.FindProductById(id));
        }

        public List<ProductDTO> GetProducts()
        {
            return ProductDAO.Instance.GetProducts().Select(p => Mapper.mapToDTO(p)).ToList();
        }

        public List<ProductDTO> GetProductsByCategory(int id)
        {
            return ProductDAO.Instance.FindProductByCategoryId(id).Select(p => Mapper.mapToDTO(p)).ToList();
        }

        public void SaveProduct(ProductDTO p)
        {
            ProductDAO.Instance.SaveProduct(Mapper.mapToEntity(p));
        }

        public void UpdateProduct(ProductDTO p)
        {
            ProductDAO.Instance.UpdateProduct(Mapper.mapToEntity(p));
        }
    }
}
