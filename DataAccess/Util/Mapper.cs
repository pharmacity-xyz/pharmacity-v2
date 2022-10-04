using BusinessObjects.Model;
using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Util
{
    public class Mapper
    {
        public static UserDTO? mapToDTO(User user)
        {
            if (user != null)
            {
                return new UserDTO
                {
                    UserId = user.UserId,
                    Email = user.Email,
                    Country = user.Country,
                    CompanyName = user.CompanyName,
                    City = user.City,
                    Password = user.Password,
                    Role = user.Role
                };
            }
            else
            {
                return null;
            }

        }

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

        // public static OrderDetailDTO mapToDTO(OrderDetail orderDetail)
        // {
        //     OrderDetailDTO? orderDetailDTO = orderDetail == null ? null : new OrderDetailDTO
        //     {
        //         OrderDetailId = orderDetail.OrderDetailId,
        //         ProductId = orderDetail.ProductId,
        //         Price = orderDetail.Price,
        //         ProductName = orderDetail.Product!.ProductName,
        //         Quantity = orderDetail.Quantity,
        //         TotalPrice = (double)orderDetail.Price! * (double)orderDetail.Quantity!,
        //         OrderForeignKey = orderDetail.OrderForeignKey
        //     };

        //     return orderDetailDTO!;
        // }

        public static ProductDTO mapToDTO(Product product)
        {
            ProductDTO productDTO = new ProductDTO
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Price = product.Price,
                UnitsInStock = product.UnitInStock,
                CategoryId = product.CategoryId,
                // CategoryName = product.Category?.Name
            };
            return productDTO;
        }

        public static CategoryDTO mapToDTO(Category category)
        {
            CategoryDTO categoryDTO = new CategoryDTO
            {
                CategoryId = category.CategoryId,
                CategoryName = category.Name
            };
            return categoryDTO;
        }

        public static User mapToEntity(UserDTO userDTO)
        {
            User user = new User
            {
                UserId = userDTO.UserId,
                Email = userDTO.Email,
                Country = userDTO.Country,
                CompanyName = userDTO.CompanyName,
                City = userDTO.City,
                Password = userDTO.Password,
                Role = userDTO.Role?.ToString()
            };

            return user;
        }

        public static Order mapToEntity(OrderDTO orderDTO)
        {
            Order order = new Order
            {
                UserId = orderDTO.UserId,
                OrderedDate = orderDTO.OrderedDate,
                OrderId = orderDTO.OrderId,
                ShipDate = orderDTO.ShipDate,
                // OrderDetail = mapToEntity(orderDTO.OrderDetail!)
            };
            return order;
        }

        // public static OrderDetail mapToEntity(OrderDetailDTO orderDetailDTO)
        // {
        //     OrderDetail orderDetail = new OrderDetail
        //     {
        //         OrderDetailId = orderDetailDTO.OrderDetailId,
        //         ProductId = orderDetailDTO.ProductId,
        //         Quantity = orderDetailDTO.Quantity,
        //         Price = orderDetailDTO.Price,
        //         OrderForeignKey = orderDetailDTO.OrderForeignKey,
        //     };

        //     return orderDetail;
        // }

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

        public static Category mapToEntity(CategoryDTO categoryDTO)
        {
            Category category = new Category
            {
                CategoryId = categoryDTO.CategoryId,
                Name = categoryDTO.CategoryName
            };
            return category;
        }
    }
}
