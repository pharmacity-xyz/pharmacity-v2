﻿using StoreAPI.DTO;
using StoreAPI.Models;

namespace StoreAPI.Services
{
    public class OrderService : IOrderService
    {
        public Guid Add(OrderDTO orderDTO)
        {
            // Order newOrder = new Order
            // {
            //     OrderId = Guid.NewGuid(),
            //     Amount = orderDTO.Amount,
            //     ShipAddress = orderDTO.ShipAddress,
            //     OrderDate = DateTime.UtcNow,
            //     ShippedDate = orderDTO.ShippedDate,
            //     UserId = orderDTO.UserId,
            // };
            // OrderDAO.Instance.Add(newOrder);
            // return newOrder.OrderId;
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDTO> GetAllOrders()
        {
            // return OrderDAO.Instance.GetAllOrders().Select(p => OrderMapper.mapToDTO(p)).ToList();
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDTO> GetAllOrdersByUserId(Guid id)
        {
            // return OrderDAO.Instance.SearchByUserId(id).Select(p => OrderMapper.mapToDTO(p)).ToList();
            throw new NotImplementedException();
        }

        public OrderDTO GetOrderById(Guid id)
        {
            // return OrderMapper.mapToDTO(OrderDAO.Instance.GetById(id));
            throw new NotImplementedException();
        }

        public void Update(OrderDTO orderDTO)
        {
            // Order order = OrderDAO.Instance.GetById(orderDTO.OrderId);
            // Order tempOrder = new Order
            // {
            //     OrderId = order.OrderId,
            //     Amount = orderDTO.Amount,
            //     ShipAddress = orderDTO.ShipAddress,
            //     OrderDate = order.OrderDate,
            //     ShippedDate = orderDTO.ShippedDate,
            //     UserId = orderDTO.UserId,
            // };
            // OrderDAO.Instance.Update(tempOrder);
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            // OrderDAO.Instance.Delete(id);
            throw new NotImplementedException();
        }
    }
}
