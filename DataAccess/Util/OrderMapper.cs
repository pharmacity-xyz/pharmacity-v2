using BusinessObjects.Model;
using DataAccess.DTO;

namespace DataAccess.Util
{
    public class OrderMapper
    {
        public static OrderDTO mapToDTO(Order order)
        {
            return new OrderDTO
            {
                OrderId = order.OrderId,
                Amount = order.Amount,
                ShipAddress = order.ShipAddress,
                OrderDate = order.OrderDate,
                ShippedDate = order.ShippedDate,
                UserId = order.UserId,
            };
        }

        // public static Order mapToEntity(OrderDTO orderDTO)
        // {
        //     return new Order
        //     {
        //         OrderId = orderDTO.OrderId,
        //         OrderDate = orderDTO.OrderDate,
        //         ShipDate = orderDTO.ShipDate,
        //         UserId = orderDTO.UserId,
        //     };
        // }
    }
}
