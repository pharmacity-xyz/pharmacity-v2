using BusinessObjects.Model;
using DataAccess.DTO;

namespace DataAccess.Util
{
    public class ProductImageMapper
    {
        public static ProductImageDTO mapToDTO(ProductImage productImage)
        {
            return new ProductImageDTO
            {
                ProductImageId = productImage.ProductImageId,
                Image = productImage.Image!,
                Caption = productImage.Caption,
            };
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