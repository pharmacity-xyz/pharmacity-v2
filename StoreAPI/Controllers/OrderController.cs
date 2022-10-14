﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using StoreAPI.DTO;
using StoreAPI.Services;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // [HttpPost("add")]
        // public IActionResult Add(OrderDTO newOrder)
        // {
        //     try
        //     {
        //         newOrder.ShippedDate = DateTime.UtcNow;
        //         Guid orderId = _orderService.Add(newOrder);
        //         // orderDetailRepository.Add(newOrder.OrderDetail!, orderId);

        //         return Ok("Successfully added");
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }

        [HttpGet]
        public IActionResult GetOrders()
        {

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderDetails(Guid orderId)
        {

            return Ok();

        }

        // [HttpGet("get_all_by_userid/{userid}")]
        // public IActionResult GetAll(Guid userid)
        // {
        //     try
        //     {
        //         // UserDTO user = LoggedUser.Instance!.User!;

        //         // if (user == null)
        //         // {
        //         //     throw new Exception("Please login");
        //         // }

        //         // IEnumerable<OrderDTO> orderList = orderRepository.GetAllOrdersByUserId(userid);
        //         // foreach (OrderDTO orderDTO in orderList)
        //         // {
        //         //     orderDTO.OrderDetail = orderDetailRepository.GetOrderDetailByOrderID(orderDTO.OrderId);
        //         // }
        //         // return Ok(orderList);
        //         return Ok();
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }

        // [HttpDelete("delete/{id}")]
        // public IActionResult Delete(Guid id)
        // {
        //     try
        //     {
        //         // orderDetailRepo.Delete(id);
        //         _orderService.Delete(id);
        //         return Ok("Successfully deleted");
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }
    }
}
