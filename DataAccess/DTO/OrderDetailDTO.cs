namespace DataAccess.DTO
{
    public class OrderDetailDTO
    {
        public Guid? OrderDetailId { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }

        public Guid OrderId { get; set; }

        public Guid ProductId { get; set; }
    }
}