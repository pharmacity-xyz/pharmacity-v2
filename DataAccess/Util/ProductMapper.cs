using BusinessObjects.Model;
using DataAccess.DTO;

namespace DataAccess.Util
{
    public class ProductMapper
    {
        public static ProductDTO mapToDTO(Product product)
        {
            ProductDTO productDTO = new ProductDTO
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName!,
                ProductDetail = product.ProductDetail!,
                Price = product.Price,
                UnitsInStock = product.UnitInStock,
                CategoryId = product.CategoryId,
            };
            return productDTO;
        }

        // public static Product mapToEntity(ProductDTO productDTO)
        // {
        //     Product product = new Product
        //     {
        //         ProductId = productDTO.ProductId,
        //         ProductName = productDTO.ProductName,
        //         Price = productDTO.Price,
        //         UnitInStock = productDTO.UnitsInStock,
        //         CategoryId = productDTO.CategoryId
        //     };
        //     return product;
        // }

    }
}