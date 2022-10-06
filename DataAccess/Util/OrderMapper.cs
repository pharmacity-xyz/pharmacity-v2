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
    }
}
