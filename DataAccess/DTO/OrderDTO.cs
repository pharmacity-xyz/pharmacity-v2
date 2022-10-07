namespace DataAccess.DTO
{
    public class OrderDTO
    {
        public Guid? OrderId { get; set; }
        public float Amount { get; set; }
        public string ShipAddress { get; set; } = default!;
        public DateTime? OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }

        public Guid UserId { get; set; }

        public OrderDetailDTO? OrderDetail { get; set; }
    }
}
