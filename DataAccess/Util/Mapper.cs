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
                OrderDate = order.OrderDate,
                OrderId = order.OrderId,
                RequiredDate = order.RequiredDate,
                ShippedDate = order.ShippedDate,
                Freight = order.Freight,
            };
            return orderDTO;
        }

        public static OrderDetailDTO mapToDTO(OrderDetail orderDetail)
        {
            OrderDetailDTO? orderDetailDTO = orderDetail == null ? null : new OrderDetailDTO
            {
                Discount = (double)orderDetail.Discount!,
                OrderId = orderDetail.OrderDetailId,
                ProductId = orderDetail.ProductId,
                ProductName = orderDetail.Product!.ProductName,
                Quantity = orderDetail.Quantity,
                UnitPrice = orderDetail.UnitPrice,
                TotalPrice = (double)orderDetail.UnitPrice! * (double)orderDetail.Quantity! * (1d - (double)orderDetail.Discount)
            };

            return orderDetailDTO!;
        }

        public static ProductDTO mapToDTO(Product product)
        {
            ProductDTO productDTO = new ProductDTO
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitInStock,
                Weight = product.Weight,
                CategoryId = product.CategoryId,
                CategoryName = product.Category?.Name
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
                OrderDate = orderDTO.OrderDate,
                OrderId = orderDTO.OrderId,
                RequiredDate = orderDTO.RequiredDate,
                ShippedDate = orderDTO.ShippedDate,
                Freight = orderDTO.Freight,
                OrderDetail = mapToEntity(orderDTO.OrderDetail!)
            };
            return order;
        }

        public static OrderDetail mapToEntity(OrderDetailDTO orderDetailDTO)
        {
            OrderDetail orderDetail = new OrderDetail
            {
                Discount = (float?)orderDetailDTO.Discount,
                OrderDetailId = orderDetailDTO.OrderId,
                ProductId = orderDetailDTO.ProductId,
                Quantity = orderDetailDTO.Quantity,
                UnitPrice = orderDetailDTO.UnitPrice
            };

            return orderDetail;
        }

        public static Product mapToEntity(ProductDTO productDTO)
        {
            Product product = new Product
            {
                ProductId = productDTO.ProductId,
                ProductName = productDTO.ProductName,
                UnitPrice = productDTO.UnitPrice,
                UnitInStock = productDTO.UnitsInStock,
                Weight = productDTO.Weight,
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
