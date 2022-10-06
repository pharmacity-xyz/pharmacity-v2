namespace DataAccess.DTO
{
    public class OrderDetailDTO
    {
        public Guid? OrderDetailId { get; set; }
        public float Price { get; set; }
        public int? Quantity { get; set; }

        public int? OrderId { get; set; }

        public int? ProductId { get; set; }
    }
}