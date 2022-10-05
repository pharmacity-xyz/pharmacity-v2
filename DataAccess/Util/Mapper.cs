using BusinessObjects.Model;
using DataAccess.DTO;

namespace DataAccess.Util
{
    public class Mapper
    {
        public static OrderDTO mapToDTO(Order order)
        {
            OrderDTO orderDTO = new OrderDTO
            {
                UserId = order.UserId,
                OrderedDate = order.OrderedDate,
                OrderId = order.OrderId,
                ShipDate = order.ShipDate,
            };
            return orderDTO;
        }

        public static ProductDTO mapToDTO(Product product)
        {
            ProductDTO productDTO = new ProductDTO
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Price = product.Price,
                UnitsInStock = product.UnitInStock,
                CategoryId = product.CategoryId,
            };
            return productDTO;
        }





        public static Order mapToEntity(OrderDTO orderDTO)
        {
            return new Order
            {
                OrderId = orderDTO.OrderId,
                OrderedDate = orderDTO.OrderedDate,
                ShipDate = orderDTO.ShipDate,
                UserId = orderDTO.UserId,
            };
        }

        public static Product mapToEntity(ProductDTO productDTO)
        {
            Product product = new Product
            {
                ProductId = productDTO.ProductId,
                ProductName = productDTO.ProductName,
                Price = productDTO.Price,
                UnitInStock = productDTO.UnitsInStock,
                CategoryId = productDTO.CategoryId
            };
            return product;
        }


    }
}
