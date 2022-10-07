using BusinessObjects.Model;
using DataAccess.DTO;

namespace DataAccess.Util
{
    public class OrderDetailMapper
    {
        public static OrderDetailDTO mapToDTO(OrderDetail orderDetail)
        {
            OrderDetailDTO? orderDetailDTO = orderDetail == null ? null : new OrderDetailDTO
            {
                OrderDetailId = orderDetail.OrderDetailId,
                Price = orderDetail.Price,
                Quantity = orderDetail.Quantity,
                OrderId = orderDetail.OrderId,
                ProductId = orderDetail.ProductId,
            };

            return orderDetailDTO!;
        }

        // public static OrderDetail mapToEntity(OrderDetailDTO orderDetailDTO)
        // {
        //     OrderDetail orderDetail = new OrderDetail
        //     {
        //         OrderDetailId = orderDetailDTO.OrderDetailId,
        //         Discount = (float?)orderDetailDTO.Discount,
        //         OrderId = orderDetailDTO.OrderId,
        //         ProductId = orderDetailDTO.ProductId,
        //         Quantity = orderDetailDTO.Quantity,
        //         UnitPrice = orderDetailDTO.UnitPrice
        //     };

        //     return orderDetail;
        // }
    }
}